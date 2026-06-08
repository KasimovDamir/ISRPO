using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private const int CellSize = 20;
        private const int GridWidth = 30;
        private const int GridHeight = 20;
        private List<Point> snake;
        private Point food;
        private Direction currentDirection;
        private int score;
        private bool isGameOver;
        private DateTime gameStartTime;
        

        private readonly Random rand = new Random();

        public enum Direction { Up, Down, Left, Right }

        public Form1()
        {
            InitializeComponent();
            this.Text = "Змейка";

         
            this.Size = new Size(GridWidth * CellSize + 20, GridHeight * CellSize + 100);

            this.StartPosition = FormStartPosition.CenterScreen;

            
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            this.KeyPreview = true;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;

            gameTimer = new Timer();
            gameTimer.Interval = 150;
            gameTimer.Tick += GameTimer_Tick;

            StartNewGame();
        }

        private void StartNewGame()
        {
            snake = new List<Point> { new Point(5, 5), new Point(4, 5), new Point(3, 5) };
            currentDirection = Direction.Right;
            score = 0;
            isGameOver = false;
            gameStartTime = DateTime.Now;
            GenerateFood();
            gameTimer.Start();
            this.Invalidate();
        }

        private void GenerateFood()
        {
            do
            {
                food = new Point(rand.Next(0, GridWidth), rand.Next(0, GridHeight));
            } while (snake.Contains(food));
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;
            MoveSnake();
            CheckCollision();
            this.Invalidate();
        }

        private void MoveSnake()
        {
            Point head = snake[0];
            Point newHead;
            switch (currentDirection)
            {
                case Direction.Up:
                    newHead = new Point(head.X, head.Y - 1);
                    break;
                case Direction.Down:
                    newHead = new Point(head.X, head.Y + 1);
                    break;
                case Direction.Left:
                    newHead = new Point(head.X - 1, head.Y);
                    break;
                case Direction.Right:
                    newHead = new Point(head.X + 1, head.Y);
                    break;
                default:
                    newHead = head;
                    break;
            }
            snake.Insert(0, newHead);
            if (newHead == food)
            {
                score += 10;
                GenerateFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }

        private void CheckCollision()
        {
            Point head = snake[0];
            if (head.X < 0 || head.X >= GridWidth || head.Y < 0 || head.Y >= GridHeight)
            {
                GameOver();
                return;
            }
            for (int i = 1; i < snake.Count; i++)
            {
                if (head == snake[i])
                {
                    GameOver();
                    return;
                }
            }
        }

        private void GameOver()
        {
            isGameOver = true;
            gameTimer.Stop();
            TimeSpan gameDuration = DateTime.Now - gameStartTime;
            int durationSeconds = (int)gameDuration.TotalSeconds;

            string playerName = Microsoft.VisualBasic.Interaction.InputBox("Игра окончена!\n\nВаш счёт: " + score + "\n\nВведите ваше имя:", "Сохранение результата", "Игрок1");

            if (!string.IsNullOrWhiteSpace(playerName))
            {
                SaveResult(playerName, durationSeconds);
            }

            DialogResult result = MessageBox.Show("Сыграть ещё раз?", "Конец игры", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                StartNewGame();
            }
            else
            {
                Application.Exit();
            }
        }

        private void SaveResult(string playerName, int durationSeconds)
        {
            string connectionString = "Server=DESKTOP-ISD67OP\\SQLEXPRESS;Database=SnakeGameDB;Trusted_Connection=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO GameResults (PlayerName, Score, GameDuration, GameDate) VALUES (@PlayerName, @Score, @GameDuration, @GameDate)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PlayerName", playerName);
                        cmd.Parameters.AddWithValue("@Score", score);
                        cmd.Parameters.AddWithValue("@GameDuration", durationSeconds);
                        cmd.Parameters.AddWithValue("@GameDate", DateTime.Now);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Результат успешно сохранён в базу данных!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения в базу данных:\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (currentDirection != Direction.Down) currentDirection = Direction.Up;
                    break;
                case Keys.Down:
                    if (currentDirection != Direction.Up) currentDirection = Direction.Down;
                    break;
                case Keys.Left:
                    if (currentDirection != Direction.Right) currentDirection = Direction.Left;
                    break;
                case Keys.Right:
                    if (currentDirection != Direction.Left) currentDirection = Direction.Right;
                    break;
                case Keys.Space:
                    if (isGameOver) StartNewGame();
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            
            g.Clear(Color.White);


            g.DrawRectangle(Pens.Black, 2, 0, GridWidth * CellSize, GridHeight * CellSize);

            foreach (Point p in snake)
            {
               
                g.FillRectangle(Brushes.LimeGreen, p.X * CellSize + 1, p.Y * CellSize + 1, CellSize - 2, CellSize - 2);
            }

         
            g.FillEllipse(Brushes.OrangeRed, food.X * CellSize + 2, food.Y * CellSize + 2, CellSize - 4, CellSize - 4);

           
            g.DrawString("Счёт: " + score, new Font("Aptos", 12, FontStyle.Regular), Brushes.Black, new PointF(10, GridHeight * CellSize + 10));
            g.DrawString("Время: " + (DateTime.Now - gameStartTime).ToString(@"mm\:ss"), new Font("Aptos", 12, FontStyle.Regular), Brushes.Black, new PointF(140, GridHeight * CellSize + 10));
        }
    }
}