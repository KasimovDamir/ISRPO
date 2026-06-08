using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyPlaner
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=DESKTOP-ISD67OP\SQLEXPRESS;Initial Catalog=DailyPlanerDB;Integrated Security=True";
        int selectedId = -1;

        public Form1()
        {
            InitializeComponent();
            LoadNotes();
            dateTimePickerTime.Value = DateTime.Now;
        }

        class NoteItem
        {
            public int Id;
            public string Display;
            public string FullText;
            public DateTime Time;

            public override string ToString()
            {
                return Display;
            }
        }

        void LoadNotes()
        {
            listNotes.Items.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT Id, NoteDate, NoteText FROM Notes WHERE CAST(NoteDate AS DATE)=@date ORDER BY NoteDate";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@date", monthCalendar1.SelectionStart.Date);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["Id"];
                    DateTime date = (DateTime)reader["NoteDate"];
                    string text = reader["NoteText"].ToString();

                    string shortText = text.Length > 50 ? text.Substring(0, 50) + "..." : text;

                    listNotes.Items.Add(new NoteItem
                    {
                        Id = id,
                        Display = date.ToString("HH:mm") + " - " + shortText,
                        FullText = text,
                        Time = date
                    });
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNote.Text))
            {
                MessageBox.Show("Введите текст заметки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime date = monthCalendar1.SelectionStart.Date
                .Add(dateTimePickerTime.Value.TimeOfDay);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "INSERT INTO Notes (NoteDate, NoteText, CreatedAt) VALUES (@date, @text, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@text", textBoxNote.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Заметка успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxNote.Clear();
            LoadNotes();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Выберите заметку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNote.Text))
            {
                MessageBox.Show("Введите текст!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime date = monthCalendar1.SelectionStart.Date
                .Add(dateTimePickerTime.Value.TimeOfDay);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "UPDATE Notes SET NoteDate=@date, NoteText=@text WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@text", textBoxNote.Text);
                cmd.Parameters.AddWithValue("@id", selectedId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Обновлено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadNotes();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxNote.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Выберите заметку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Удалить заметку?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "DELETE FROM Notes WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", selectedId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Удалено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxNote.Clear();
            selectedId = -1;
            LoadNotes();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadNotes();
        }

        private void listNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listNotes.SelectedItem is NoteItem item)
            {
                selectedId = item.Id;
                textBoxNote.Text = item.FullText;
                dateTimePickerTime.Value = item.Time;
            }
        }

        private void listBoxNotes_MouseMove(object sender, MouseEventArgs e)
        {
            int index = listNotes.IndexFromPoint(e.Location);

            if (index >= 0)
            {
                if (listNotes.Items[index] is NoteItem item)
                {
                    toolTip1.SetToolTip(listNotes, item.FullText);
                }
            }
        }
    }
}