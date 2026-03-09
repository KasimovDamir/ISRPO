using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practikum
{
    public partial class Form1 : Form
    {
        Dictionary<string, double> rates = new Dictionary<string, double>()
        {
            { "Российский рубль", 1.0 },
            { "Доллар США", 77.70 },
            { "Евро", 90.34 },
            { "Китайский юань", 10.96 },
            { "Южнокорейская вона", 0.0670 }
        };

        Dictionary<string, string> symbols = new Dictionary<string, string>()
        {
            { "Российский рубль", "₽" },
            { "Доллар США", "$" },
            { "Евро", "€" },
            { "Китайский юань", "¥" },
            { "Южнокорейская вона", "₩" }
        };

        public Form1()
        {
            InitializeComponent();
            InitCurrencies();
            UpdateRatesLabel();
        }

        private void InitCurrencies()
        {
            comboBoxFrom.Items.AddRange(rates.Keys.ToArray());
            comboBoxTo.Items.AddRange(rates.Keys.ToArray());

            comboBoxFrom.SelectedIndex = 0;
            comboBoxTo.SelectedIndex = 1;

            UpdateSymbols();
        }

        private void UpdateSymbols()
        {
            if (comboBoxFrom.SelectedItem != null)
                labelFromSign.Text = symbols[comboBoxFrom.SelectedItem.ToString()];

            if (comboBoxTo.SelectedItem != null)
                labelToSign.Text = symbols[comboBoxTo.SelectedItem.ToString()];
        }

        private void ConvertCurrency()
        {
            if (!double.TryParse(textBoxAmount.Text.Replace('.', ','), out double amount))
            {
                textBoxResult.Text = "";
                return;
            }

            string from = comboBoxFrom.SelectedItem.ToString();
            string to = comboBoxTo.SelectedItem.ToString();

            double rub = amount * rates[from];
            double result = rub / rates[to];

            textBoxResult.Text = result.ToString("F2");
        }

        private void UpdateRatesLabel()
        {
            labelRates.Text =
                $"1 USD = {rates["Доллар США"]} RUB\n" +
                $"1 EUR = {rates["Евро"]} RUB\n" +
                $"1 CNY = {rates["Китайский юань"]} RUB\n" +
                $"1 KRW = {rates["Южнокорейская вона"]} RUB";
        }

        private void comboBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSymbols();
            
        }

        private void comboBoxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSymbols();
            
        }

        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Курсы валют обновлены", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateRatesLabel();
            ConvertCurrency();
        }
    }
}
