using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PublishingApp.Models;

namespace PublishingApp
{
    public partial class MainForm : Form
    {
        private List<Book> books;

        public MainForm()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                using (var db = new DatabaseHelper())
                {
                    books = db.GetBooks();
                    dataGridViewBooks.DataSource = books;
                }

                dataGridViewBooks.Columns["Id"].Visible = false;
                dataGridViewBooks.Columns["AuthorId"].Visible = false;
                dataGridViewBooks.Columns["Circulation"].Visible = false;

                dataGridViewBooks.Columns["Title"].HeaderText = "Название";
                dataGridViewBooks.Columns["AuthorName"].HeaderText = "Автор";
                dataGridViewBooks.Columns["ReleaseYear"].HeaderText = "Год";
                dataGridViewBooks.Columns["Pages"].HeaderText = "Страниц";
                dataGridViewBooks.Columns["Price"].HeaderText = "Цена";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки книг:\n" + ex.Message);
            }
        }

        private void dataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null) return;

            var book = dataGridViewBooks.CurrentRow.DataBoundItem as Book;
            if (book == null) return;

            txtTitle.Text = book.Title;
            txtAuthor.Text = book.AuthorName;
            txtYear.Text = book.ReleaseYear.ToString();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow == null)
            {
                MessageBox.Show("Выберите книгу.");
                return;
            }

            var book = dataGridViewBooks.CurrentRow.DataBoundItem as Book;

            using (var orderForm = new FormOrder(book))
            {
                orderForm.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}