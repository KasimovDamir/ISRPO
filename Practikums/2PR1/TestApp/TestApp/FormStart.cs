using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class FormStart : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        public FormStart()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonStartTest_Click(object sender, EventArgs e)
        {
            int userId;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"INSERT INTO Users (FirstName, LastName, TestDate, IsCompleted)
                           OUTPUT INSERTED.Id
                           VALUES (@fn, @ln, GETDATE(), 0)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@fn", textBoxFirstName.Text);
                cmd.Parameters.AddWithValue("@ln", textBoxLastName.Text);

                userId = (int)cmd.ExecuteScalar();
            }

            FormQuestion f = new FormQuestion(userId);
            f.Show();
            this.Hide();

        }
    }
}
