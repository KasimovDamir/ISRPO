using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestApp
{
    public partial class FormFinish : Form
    {
        int userId;
        string connStr = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        public FormFinish(int id, int correct, int total, int percent)
        {
            InitializeComponent();

            userId = id;

            labelResult.Text = $"Правильных ответов: {correct} из {total}";
            labelPercent.Text = $"Результат: {percent}%";

            LoadUser();
        }

        void LoadUser()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT FirstName, LastName, TestDate, Score, TimeSpent FROM Users WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["FirstName"].ToString());

                    item.SubItems.Add(reader["LastName"].ToString());
                    item.SubItems.Add(reader["TestDate"].ToString());
                    item.SubItems.Add(reader["Score"].ToString() + "%");
                    item.SubItems.Add(reader["TimeSpent"].ToString() + " сек");

                    listViewUser.Items.Add(item);
                }
            }
        }

        private void buttonRetry_Click(object sender, EventArgs e)
        {
            FormStart f = new FormStart();
            f.Show();
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}