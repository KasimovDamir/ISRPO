using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PublishingApp.Models;

namespace PublishingApp
{
    public partial class FormOrder : Form
    {
        private Book selectedBook;
        private List<Office> offices;

        public FormOrder(Book book)
        {
            InitializeComponent();
            selectedBook = book;

            lblBook.Text = $"Название: {book.Title}";
            lblAuthor.Text = $"Автор: {book.AuthorName}";

            LoadOffices();
            UpdateTotal();
        }

        private void LoadOffices()
        {
            try
            {
                using (var db = new DatabaseHelper())
                {
                    offices = db.GetOffices();
                    cmbOffice.DataSource = offices;
                    cmbOffice.DisplayMember = "Name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки офисов:\n" + ex.Message);
            }
        }

        private void numCount_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = selectedBook.Price * (decimal)numCount.Value;
            lblTotal.Text = FormatPrice(total);
        }

        private string FormatPrice(decimal price)
        {
            return $"Итого: {price:F2} руб.";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFio.Text))
            {
                MessageBox.Show("Введите ФИО клиента.");
                return;
            }

            if (cmbOffice.SelectedItem == null)
            {
                MessageBox.Show("Выберите офис.");
                return;
            }

            try
            {
                using (var db = new DatabaseHelper())
                {
                    var customer = new Customer
                    {
                        Name = txtFio.Text,
                        Address = txtAddress.Text,
                        Phone = txtPhone.Text
                    };

                    int customerId = db.CreateCustomer(customer);

                    var order = new Order
                    {
                        BookId = selectedBook.Id,
                        OfficeId = ((Office)cmbOffice.SelectedItem).Id,
                        CustomerId = customerId,
                        OrderDate = DateTime.Now,
                        CompletionDate = DateTime.Now.AddDays(14),
                        Price = selectedBook.Price * (decimal)numCount.Value
                    };

                    int orderId = db.CreateOrder(order);

                    var orderDetails = db.GetOrderDetails(orderId);

                    using (var receiptForm = new FormReceipt(orderDetails))
                    {
                        receiptForm.ShowDialog();
                    }
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка оформления заказа:\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}