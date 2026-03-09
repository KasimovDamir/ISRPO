using System;
using System.Windows.Forms;
using PublishingApp.Models;

namespace PublishingApp
{
    public partial class FormReceipt : Form
    {
        private Order order;

        public FormReceipt(Order order)
        {
            InitializeComponent();
            this.order = order;
            GenerateReceipt();
        }

        private void GenerateReceipt()
        {
            lblReceipt.Text =
                "ИЗДАТЕЛЬСТВО \"КНИГА\"\n\n" +
                "КАССОВЫЙ ЧЕК\n\n" +
                $"Номер заказа: {order.Id}\n" +
                $"Дата: {order.OrderDate:dd.MM.yyyy HH:mm}\n\n" +
                "--------------------------------------\n" +
                $"Книга: \"{order.BookTitle}\"\n" +
                $"Клиент: {order.CustomerName}\n" +
                $"Офис получения:\n{order.OfficeName}\n\n" +
                $"Сумма к оплате:\n{order.Price:F2} руб.\n\n" +
                "--------------------------------------\n" +
                "Срок выполнения заказа:\n14 календарных дней\n\n" +
                "При себе иметь чек и документ,\nудостоверяющий личность.\n\n" +
                "__________________________\nПодпись кассира";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Печать чека не реализована.");
        }
    }
}
