using System;
using System.Linq;
using System.Windows.Forms;

namespace CeasarCipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBoxLanguage.Items.AddRange(new string[] { "Русский", "Английский" });
            comboBoxLanguage.SelectedIndex = 0;
            numericUpDownShift.Minimum = 1;
            numericUpDownShift.Maximum = 10;
            numericUpDownShift.Value = 3;
        }

        private string Caesar(string input, int shift, bool decrypt = false)
        {
            string result = "";
            string lang = comboBoxLanguage.SelectedItem.ToString();

            string alphabetLower, alphabetUpper;

            if (lang == "Русский")
            {
                alphabetLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                alphabetUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            }
            else
            {
                alphabetLower = "abcdefghijklmnopqrstuvwxyz";
                alphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            int alphaLength = alphabetLower.Length;

            if (decrypt)
                shift = -shift; 

            foreach (char c in input)
            {
                if (alphabetLower.Contains(c))
                {
                    int index = (alphabetLower.IndexOf(c) + shift) % alphaLength;
                    if (index < 0) index += alphaLength; 
                    result += alphabetLower[index];
                }
                else if (alphabetUpper.Contains(c))
                {
                    int index = (alphabetUpper.IndexOf(c) + shift) % alphaLength;
                    if (index < 0) index += alphaLength;
                    result += alphabetUpper[index];
                }
                else
                {
                    result += c; 
                }
            }

            return result;
        }

        private void buttonCipher_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxInput.Text))
            {
                MessageBox.Show("Введите текст для шифрования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int shift = (int)numericUpDownShift.Value;
            textBoxResult.Text = Caesar(textBoxInput.Text, shift);
        }

        private void buttonUnCipher_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxInput.Text))
            {
                MessageBox.Show("Введите текст для расшифровки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int shift = (int)numericUpDownShift.Value;
            textBoxResult.Text = Caesar(textBoxInput.Text, shift, decrypt: true);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxInput.Clear();
            textBoxResult.Clear();
        }
    }
}
