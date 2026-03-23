using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace FilesApp
{
    public partial class SymbolsCount : Form
    {
        string connectionString = @"Data Source=LuM1e\SQLLUM1E;Initial Catalog=FileHistory;Integrated Security=True";
        bool isFileLoaded = false;
        public SymbolsCount()
        {
            InitializeComponent();
            CreateDatabase();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateDatabase()
        {
            try
            {
                string dbPath = @"C:\ProgramData\FileHistory.mdf";

                using (SqlConnection connection = new SqlConnection(@"Data Source=LuM1e\SQLLUM1E;Integrated Security=True"))
                {
                    connection.Open();

                    string checkDbQuery = "SELECT COUNT(*) FROM sys.databases WHERE name = 'FileHistory'";

                    using (SqlCommand checkCmd = new SqlCommand(checkDbQuery, connection))
                    {
                        int dbExists = (int)checkCmd.ExecuteScalar();

                        if (dbExists == 0)
                        {
                            string createDbQuery = $@"
                    CREATE DATABASE FileHistory
                    ON (NAME = N'FileHistory', FILENAME = '{dbPath}')
                    LOG ON (NAME = N'FileHistory_log', FILENAME = '{dbPath.Replace(".mdf", "_log.ldf")}')";

                            using (SqlCommand createCmd = new SqlCommand(createDbQuery, connection))
                            {
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtPath.Text = openFileDialog.FileName;

                        string content = File.ReadAllText(openFileDialog.FileName);

                        isFileLoaded = true; 

                        txtText.Text = content;

                        txtCount.Clear(); 

                        SaveToDatabase(openFileDialog.FileName, content, 0, "Открытие");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCountUp_Click(object sender, EventArgs e)
        {
            int count = txtText.Text.Length;
            txtCount.Text = count.ToString();

            isFileLoaded = false; 

            SaveToDatabase(txtPath.Text, txtText.Text, count, "Подсчет");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, txtText.Text);

                        txtPath.Text = saveFileDialog.FileName;

                        int count = txtText.Text.Length;

                        SaveToDatabase(saveFileDialog.FileName, txtText.Text, count, "Сохранение");

                        MessageBox.Show("Файл сохранен");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtText.Clear();
            txtCount.Clear();
            txtPath.Clear();

            isFileLoaded = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            if (!isFileLoaded)
            {
                int count = txtText.Text.Length;
                txtCount.Text = count.ToString();
            }
        }

        private void SaveToDatabase(string filePath, string content, int symbolCount, string operationType)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkTableQuery = @"
              IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='FileOperations' AND xtype='U')
              BEGIN
                  CREATE TABLE FileOperations (
                      Id INT PRIMARY KEY IDENTITY(1,1),
                      FilePath NVARCHAR(500),
                      Content NVARCHAR(MAX),
                      SymbolCount INT,
                      OperationType NVARCHAR(50),
                      OperationDate DATETIME DEFAULT GETDATE()
                  )
              END";

                    using (var checkCommand = new SqlCommand(checkTableQuery, connection))
                    {
                        checkCommand.ExecuteNonQuery();
                    }

                    string insertQuery = @"
              INSERT INTO FileOperations (FilePath, Content, SymbolCount, OperationType) 
              VALUES (@FilePath, @Content, @SymbolCount, @OperationType)";

                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FilePath", filePath ?? "Без пути");
                        command.Parameters.AddWithValue("@Content", content ?? "");
                        command.Parameters.AddWithValue("@SymbolCount", symbolCount);
                        command.Parameters.AddWithValue("@OperationType", operationType);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при сохранении в БД: {ex.Message}");
            }
        }
    }
}
