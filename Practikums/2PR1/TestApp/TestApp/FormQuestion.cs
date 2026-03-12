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
    public partial class FormQuestion : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        DataTable questions = new DataTable();

        int currentQuestion = 0;
        int userId;
        int timeLeft = 1500;

        public FormQuestion(int id)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            userId = id;

            LoadQuestions();
            ShowQuestion();

            timer1.Interval = 1000;
            timer1.Start();
        }

        void LoadQuestions()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM Questions ORDER BY QuestionOrder", conn);

                da.Fill(questions);
            }
        }

        void ShowQuestion()
        {
            if (currentQuestion >= questions.Rows.Count)
            {
                FinishTest();
                return;
            }

            DataRow q = questions.Rows[currentQuestion];

            labelQuestion.Text = q["QuestionText"].ToString();

            radioButton1.Text = q["Option1"].ToString();
            radioButton2.Text = q["Option2"].ToString();
            radioButton3.Text = q["Option3"].ToString();
            radioButton4.Text = q["Option4"].ToString();

            labelNumber.Text = $"Вопрос {currentQuestion + 1} из {questions.Rows.Count}";

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        void SaveAnswer()
        {
            int selected = 0;

            if (radioButton1.Checked) selected = 1;
            if (radioButton2.Checked) selected = 2;
            if (radioButton3.Checked) selected = 3;
            if (radioButton4.Checked) selected = 4;

            if (selected == 0) return;

            DataRow q = questions.Rows[currentQuestion];

            int correct = Convert.ToInt32(q["CorrectAnswer"]);
            bool isCorrect = selected == correct;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"INSERT INTO UserAnswers
                               (UserId, QuestionId, SelectedAnswer, IsCorrect, AnswerTime)
                               VALUES (@uid,@qid,@ans,@cor,@time)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@uid", userId);
                cmd.Parameters.AddWithValue("@qid", q["Id"]);
                cmd.Parameters.AddWithValue("@ans", selected);
                cmd.Parameters.AddWithValue("@cor", isCorrect);
                cmd.Parameters.AddWithValue("@time", 1500 - timeLeft);

                cmd.ExecuteNonQuery();
            }
        }

        void FinishTest()
        {
            timer1.Stop();

            int correct = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM UserAnswers WHERE UserId=@id AND IsCorrect=1", conn);

                cmd.Parameters.AddWithValue("@id", userId);

                correct = (int)cmd.ExecuteScalar();

                int percent = correct * 100 / questions.Rows.Count;

                SqlCommand update = new SqlCommand(
                    @"UPDATE Users 
                      SET Score=@s, TimeSpent=@t, IsCompleted=1 
                      WHERE Id=@id", conn);

                update.Parameters.AddWithValue("@s", percent);
                update.Parameters.AddWithValue("@t", 1500 - timeLeft);
                update.Parameters.AddWithValue("@id", userId);

                update.ExecuteNonQuery();

                FormFinish f = new FormFinish(userId, correct, questions.Rows.Count, percent);
                f.Show();
                this.Close();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            currentQuestion++;
            ShowQuestion();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (currentQuestion == 0)
            {
                FormStart f = new FormStart();
                f.Show();
                this.Close();
                return;
            }

            currentQuestion--;
            ShowQuestion();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            labelTimer.Text = "Осталось: " +
                TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss");

            if (timeLeft <= 0)
            {
                FinishTest();
            }
        }
    }
}
