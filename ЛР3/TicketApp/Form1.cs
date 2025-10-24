using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TicketApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public void GetRandomNumAndSum()
        {
            Random rand = new Random();
            int number = rand.Next(100000, 999999);

            var digits = number.ToString().Select(digit => int.Parse(digit.ToString())).ToArray();

            int sum = digits.Take(3).Sum();
            int sum2 = digits.Skip(3).Take(3).Sum();
            lbl.Visible = false;
            
            if (sum == sum2)
            {
                lblTicket.ForeColor = Color.Green;
                lblTicket2.ForeColor = Color.Green;
                lblTicket.Text = $"{number}";
                lblTicket2.Text = "Счастливый билет";
            }
            else
            {
                lblTicket.ForeColor= Color.Red;
                lblTicket2.ForeColor= Color.Red;
                lblTicket.Text = $"{number}";
                lblTicket2.Text = "Обычный билет";
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GetRandomNumAndSum();
        }
    }
}
