using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class FormFinish : Form
    {
        int correct;
        int total;
        int percent;

        public FormFinish(int c, int t, int p)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            correct = c;
            total = t;
            percent = p;

            labelResult.Text = $"Правильных ответов: {correct} из {total}";
            labelPercent.Text = $"Результат: {percent}%";
        }

        private void buttonRetry_Click(object sender, EventArgs e)
        {
            FormStart f = new FormStart();
            f.Show();
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
