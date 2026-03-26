using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WordgameApp
{
    public partial class GameForm : Form
    {
        string connectionString = @"Data Source=LuM1e\SQLLUM1E;Initial Catalog=Wordly;Integrated Security=True";

        string currentWord = "";
        Stack<Button> history = new Stack<Button>(); 
        public GameForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            currentWord = GetRandomWordFromDB();

            string shuffled = ShuffleWord(currentWord);

            panelLetters.Controls.Clear();

            int x = 10;
            int y = 10;

            int countInRow = 0; 

            foreach (char letter in shuffled)
            {
                Button btn = new Button();

                btn.Text = letter.ToString();
                btn.Width = 40;
                btn.Height = 40;

                btn.Left = x;
                btn.Top = y;

                btn.Click += Letter_Click;

                panelLetters.Controls.Add(btn);

                x += 45;
                countInRow++;

                if (countInRow == 10)
                {
                    countInRow = 0;
                    x = 10;
                    y += 45;
                }
            }
        }

        private void Letter_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null || !btn.Enabled)
                return;

            txtResult.Text += btn.Text; 
            btn.Enabled = false;        

            history.Push(btn);          
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (history.Count == 0)
                return;

            Button last = history.Pop();

            last.Enabled = true;

            if (txtResult.Text.Length > 0)
                txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string userWord = txtResult.Text;

            if (userWord.ToLower() == currentWord.ToLower())
                MessageBox.Show("Правильно! Слово угадано!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Неправильно! Слово отгадано неверно!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private string GetRandomWordFromDB()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT TOP 1 Word FROM Words ORDER BY NEWID()";

                SqlCommand cmd = new SqlCommand(query, conn);

                return cmd.ExecuteScalar().ToString();
            }
        }

        private string ShuffleWord(string word)
        {
            Random rnd = new Random();
            return new string(word.ToCharArray().OrderBy(x => rnd.Next()).ToArray());
        }
    }
}
