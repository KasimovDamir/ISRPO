using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class AlarmEditDialog : Form
    {
        public DateTime AlarmTime { get; private set; }
        public bool IsActive { get; private set; }
        public bool Repeat { get; private set; }
        public string AlarmName { get; private set; }

        public AlarmEditDialog()
        {
            InitializeComponent();

            numericUpDownTime.Value = 0;
            SetCurrentTime();

            UpdateDisplay();
        }

        public AlarmEditDialog(Alarm alarm)
        {
            InitializeComponent();

            int seconds = alarm.Time.Hour * 3600 +
                          alarm.Time.Minute * 60 +
                          alarm.Time.Second;

            numericUpDownTime.Value = seconds;

            checkBoxActivity.Checked = alarm.IsActive;
            checkBoxRepeat.Checked = alarm.Repeat;
            textBoxName.Text = alarm.Name;

            UpdateDisplay();
        }

        private void NumericUpDownTime_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownTime.Value >= 86399)
                numericUpDownTime.Value = 0;

            if (numericUpDownTime.Value <= 0)
                numericUpDownTime.Value = 86399;

            UpdateDisplay();
        }


        void UpdateDisplay()
        {
            int total = (int)numericUpDownTime.Value;

            int h = total / 3600;
            int m = (total % 3600) / 60;
            int s = total % 60;

            labelTimePreview.Text = $"{h:D2}:{m:D2}:{s:D2}";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int total = (int)numericUpDownTime.Value;

            int h = total / 3600;
            int m = (total % 3600) / 60;
            int s = total % 60;

            AlarmTime = DateTime.Today.AddHours(h).AddMinutes(m).AddSeconds(s);

            IsActive = checkBoxActivity.Checked;
            Repeat = checkBoxRepeat.Checked;
            AlarmName = textBoxName.Text;

            MessageBox.Show("Будильник успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        void SetCurrentTime()
        {
            DateTime now = DateTime.Now;

            int seconds = now.Hour * 3600 +
                          now.Minute * 60 +
                          now.Second;

            numericUpDownTime.Value = seconds;
        }
    }
}
