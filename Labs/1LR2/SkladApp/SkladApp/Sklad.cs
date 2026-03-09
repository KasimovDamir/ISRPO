using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SkladApp
{
    public partial class Sklad : Form
    {
        private string connectionString = @"Data Source=LuM1e\SQLLUM1E;Initial Catalog=sklad;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable table;

        public Sklad()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void LoadData()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "SELECT * FROM products";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void buttonAddNName_Click(object sender, EventArgs e)
        {
            string newName = textBoxNName.Text.Trim();

            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Введите новое название товара!");
                return;
            }

            foreach (var item in comboBoxName.Items)
            {
                if (item.ToString().Equals(newName, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Такое наименование уже есть в списке!");
                    return;
                }
            }

            comboBoxName.Items.Add(newName);
            textBoxNName.Clear();

            MessageBox.Show("Наименование добавлено в список!");
        }

        private void buttonAddInDGV_Click(object sender, EventArgs e)
        {
            if (comboBoxName.SelectedItem == null)
            {
                MessageBox.Show("Выберите наименование товара!");
                return;
            }

            string name = comboBoxName.SelectedItem.ToString();
            int stellage = (int)numericUpDownStl.Value;
            int cell = (int)numericUpDownCl.Value;
            int quantity = (int)numericUpDownQn.Value;

            try
            {
                connection.Open();
                string query = "INSERT INTO products (product_name, stillage, cell, quantity) VALUES (@name, @st, @cl, @qn)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@st", stellage);
                cmd.Parameters.AddWithValue("@cl", cell);
                cmd.Parameters.AddWithValue("@qn", quantity);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Товар успешно добавлен!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonDelSelected_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите строку для удаления!");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

            try
            {
                connection.Open();
                string query = "DELETE FROM products WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Товар удалён!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string search = textBoxNSr.Text.Trim();

            try
            {
                connection.Open();
                string query = "SELECT * FROM products WHERE product_name LIKE @name";
                adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + search + "%");
                table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonCoordSr_Click(object sender, EventArgs e)
        {
            int st = (int)numericUpDownSrSl.Value;
            int cl = (int)numericUpDownSrCl.Value;

            try
            {
                connection.Open();
                string query = "SELECT * FROM products WHERE stillage = @st AND cell = @cl";
                adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@st", st);
                adapter.SelectCommand.Parameters.AddWithValue("@cl", cl);
                table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSaveLike_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.Title = "Сохранить данные как";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            writer.Write(dataGridView1.Columns[i].HeaderText);
                            if (i < dataGridView1.Columns.Count - 1)
                                writer.Write("\t"); 
                        }
                        writer.WriteLine();

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0; i < row.Cells.Count; i++)
                                {
                                    writer.Write(row.Cells[i].Value?.ToString());
                                    if (i < row.Cells.Count - 1)
                                        writer.Write("\t");
                                }
                                writer.WriteLine();
                            }
                        }
                    }

                    MessageBox.Show("Данные успешно сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении файла: " + ex.Message);
            }
        }

        private void Sklad_Load(object sender, EventArgs e)
        {
            LoadData();
            FillComboBoxNames();
        }

        private void FillComboBoxNames()
        {
            try
            {
                connection.Open();
                string query = "SELECT DISTINCT product_name FROM products";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                comboBoxName.Items.Clear();
                while (reader.Read())
                {
                    comboBoxName.Items.Add(reader["product_name"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке списка наименований: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonOpen2_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Открыть файл";
                    openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        DataTable newTable = new DataTable();

                        newTable.Columns.Add("id", typeof(int));
                        newTable.Columns.Add("name", typeof(string));
                        newTable.Columns.Add("stillage", typeof(int));
                        newTable.Columns.Add("cell", typeof(int));
                        newTable.Columns.Add("quantity", typeof(int));

                        string[] lines = File.ReadAllLines(filePath);
                        bool firstLine = true;

                        foreach (string line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line))
                                continue;

                            string[] parts = line.Split(new char[] { '\t', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);

                            if (firstLine && !int.TryParse(parts[0], out _))
                            {
                                firstLine = false;
                                continue;
                            }

                            if (parts.Length < 5)
                                continue;

                            int id, stellage, cell, quantity;
                            if (!int.TryParse(parts[0], out id)) continue;
                            string name = parts[1];
                            if (!int.TryParse(parts[2], out stellage)) continue;
                            if (!int.TryParse(parts[3], out cell)) continue;
                            if (!int.TryParse(parts[4], out quantity)) continue;

                            newTable.Rows.Add(id, name, stellage, cell, quantity);
                        }

                        dataGridView1.DataSource = newTable;
                        MessageBox.Show("Данные успешно загружены из файла!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии файла: " + ex.Message);
            }
        }
    }
}

