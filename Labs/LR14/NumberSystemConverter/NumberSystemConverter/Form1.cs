using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NumberSystemConverter
{
    public partial class Form1 : Form
    {
        private readonly string _connectionString = @"Server=DESKTOP-ISD67OP\SQLEXPRESS;Database=NumberSystemsDB;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            InitializeComboBoxes();
            LoadHistory();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeComboBoxes()
        {
            string[] systems = { "Двоичная (2)", "Восьмеричная (8)", "Десятичная (10)", "Шестнадцатеричная (16)" };
            cmbFrom.Items.AddRange(systems);
            cmbTo.Items.AddRange(systems);
            cmbFrom.SelectedIndex = 2;
            cmbTo.SelectedIndex = 0;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string error;
            if (!ValidateInput(out error))
            {
                MessageBox.Show(error, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int fromBase = GetSelectedBase(cmbFrom);
                int toBase = GetSelectedBase(cmbTo);
                string input = txtInput.Text.Trim();

                long decimalValue = Convert.ToInt64(input, fromBase);
                string result = Convert.ToString(decimalValue, toBase).ToUpper();

                txtResult.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка конвертации: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput(out string error)
        {
            error = "";
            string input = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                error = "Введите число.";
                return false;
            }

            int fromBase = GetSelectedBase(cmbFrom);
            string pattern = "";

            switch (fromBase)
            {
                case 2: pattern = "^[01]+$"; break;
                case 8: pattern = "^[0-7]+$"; break;
                case 10: pattern = "^[0-9]+$"; break;
                case 16: pattern = "^[0-9A-Fa-f]+$"; break;
            }

            if (!Regex.IsMatch(input, pattern))
            {
                error = "Недопустимые символы для системы с основанием " + fromBase + ".";
                return false;
            }
            return true;
        }

        private int GetSelectedBase(ComboBox cmb)
        {
            string selected = cmb.SelectedItem as string;
            switch (selected)
            {
                case "Двоичная (2)": return 2;
                case "Восьмеричная (8)": return 8;
                case "Десятичная (10)": return 10;
                case "Шестнадцатеричная (16)": return 16;
                default: throw new ArgumentException("Неверное основание");
            }
        }

        private string GetSystemName(int baseValue)
        {
            switch (baseValue)
            {
                case 2: return "Двоичная (2)";
                case 8: return "Восьмеричная (8)";
                case 10: return "Десятичная (10)";
                case 16: return "Шестнадцатеричная (16)";
                default: return baseValue.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text))
            {
                MessageBox.Show("Сначала выполните конвертацию!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO ConversionHistory 
                            (InputNumber, InputBase, OutputNumber, OutputBase, ConversionDate) 
                            VALUES (@InputNumber, @InputBase, @OutputNumber, @OutputBase, @ConversionDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int inputBase = 0;
                        if (cmbFrom.SelectedItem != null)
                        {
                            string selected = cmbFrom.SelectedItem.ToString();
                            if (selected.Contains("(2)")) inputBase = 2;
                            else if (selected.Contains("(8)")) inputBase = 8;
                            else if (selected.Contains("(10)")) inputBase = 10;
                            else if (selected.Contains("(16)")) inputBase = 16;
                        }

                        int outputBase = 0;
                        if (cmbTo.SelectedItem != null)
                        {
                            string selected = cmbTo.SelectedItem.ToString();
                            if (selected.Contains("(2)")) outputBase = 2;
                            else if (selected.Contains("(8)")) outputBase = 8;
                            else if (selected.Contains("(10)")) outputBase = 10;
                            else if (selected.Contains("(16)")) outputBase = 16;
                        }

                        command.Parameters.AddWithValue("@InputNumber", txtInput.Text.Trim());
                        command.Parameters.AddWithValue("@InputBase", inputBase);
                        command.Parameters.AddWithValue("@OutputNumber", txtResult.Text.Trim());
                        command.Parameters.AddWithValue("@OutputBase", outputBase);
                        command.Parameters.AddWithValue("@ConversionDate", DateTime.Now);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные успешно сохранены в базу данных!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtInput.Clear();
                            txtResult.Clear();

                            LoadHistory();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Ошибка базы данных:\n" + sqlEx.Message, "Ошибка SQL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:\n" + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHistory()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT InputNumber, InputBase, OutputNumber, OutputBase, ConversionDate 
                    FROM ConversionHistory 
                    ORDER BY ConversionDate DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                   
                    dataTable.Columns.Add("InputBaseName", typeof(string));
                    dataTable.Columns.Add("OutputBaseName", typeof(string));

                   
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["InputBase"] != DBNull.Value)
                        {
                            int baseVal = Convert.ToInt32(row["InputBase"]);
                            row["InputBaseName"] = GetSystemName(baseVal);
                        }

                        if (row["OutputBase"] != DBNull.Value)
                        {
                            int baseVal = Convert.ToInt32(row["OutputBase"]);
                            row["OutputBaseName"] = GetSystemName(baseVal);
                        }
                    }

                 
                    dataTable.Columns.Remove("InputBase");
                    dataTable.Columns.Remove("OutputBase");

                    
                    dataTable.Columns["InputBaseName"].ColumnName = "InputBase";
                    dataTable.Columns["OutputBaseName"].ColumnName = "OutputBase";

                    dgvHistory.DataSource = dataTable;

                   
                    if (dgvHistory.Columns["InputNumber"] != null)
                    {
                        dgvHistory.Columns["InputNumber"].HeaderText = "Исходное число";
                        dgvHistory.Columns["InputNumber"].DisplayIndex = 0;
                    }

                    if (dgvHistory.Columns["InputBase"] != null)
                    {
                        dgvHistory.Columns["InputBase"].HeaderText = "Из системы";
                        dgvHistory.Columns["InputBase"].DisplayIndex = 1;
                    }

                    if (dgvHistory.Columns["OutputNumber"] != null)
                    {
                        dgvHistory.Columns["OutputNumber"].HeaderText = "Результат";
                        dgvHistory.Columns["OutputNumber"].DisplayIndex = 2;
                    }

                    if (dgvHistory.Columns["OutputBase"] != null)
                    {
                        dgvHistory.Columns["OutputBase"].HeaderText = "В систему";
                        dgvHistory.Columns["OutputBase"].DisplayIndex = 3;
                    }

                    if (dgvHistory.Columns["ConversionDate"] != null)
                    {
                        dgvHistory.Columns["ConversionDate"].HeaderText = "Дата конвертации";
                        dgvHistory.Columns["ConversionDate"].DisplayIndex = 4;
                        dgvHistory.Columns["ConversionDate"].Width = 150;
                    }

                  
                    if (dgvHistory.Columns["Id"] != null)
                        dgvHistory.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки истории:\n" + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}