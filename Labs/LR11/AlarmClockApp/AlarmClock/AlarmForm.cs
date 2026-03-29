using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Media;
using System.Security.Claims;
using System.Windows.Forms;
using System.Globalization;

namespace AlarmClock
{
    public partial class AlarmForm : Form
    {
        string connectionString = @"Data Source=LuM1e\SQLLUM1E;Initial Catalog=AlarmClockDB;Integrated Security=True";

        List<Alarm> alarms = new List<Alarm>();
        Alarm currentAlarm = null;

        bool isRinging = false;
        bool blink = false;

        Timer blinkTimer = new Timer();
        Timer soundTimer = new Timer();

        public AlarmForm()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Start();

            blinkTimer.Interval = 500;
            blinkTimer.Tick += BlinkTimer_Tick;

            soundTimer.Interval = 1500;
            soundTimer.Tick += SoundTimer_Tick;

            panelWarning.BackColor = Color.White;
            labelWarning.Text = "";

            LoadAlarms();
        }

        void StartAlarm(Alarm alarm)
        {
            currentAlarm = alarm;
            isRinging = true;

            labelWarning.Text = "Будильник звенит!";
            blinkTimer.Start();

            soundTimer.Start();
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            if (blink)
                panelWarning.BackColor = Color.Red;
            else
                panelWarning.BackColor = Color.White;

            blink = !blink;
        }

        private void SoundTimer_Tick(object sender, EventArgs e)
        {
            SystemSounds.Beep.Play();
        }

        void StopAlarm(string text)
        {
            blinkTimer.Stop();
            panelWarning.BackColor = Color.White;

            labelWarning.Text = text;

            isRinging = false;
            soundTimer.Stop();
        }

        void LoadAlarms()
        {
            alarms.Clear();
            dataGridView1.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Alarms";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Alarm a = new Alarm
                    {
                        Id = (int)reader["Id"],
                        Time = DateTime.Today + (TimeSpan)reader["AlarmTime"],
                        IsActive = (bool)reader["IsActive"],
                        Repeat = (bool)reader["RepeatDaily"],
                        Name = reader["Label"].ToString()
                    };

                    alarms.Add(a);

                    dataGridView1.Rows.Add(
                        a.IsActive,
                        a.Time.ToString("HH:mm:ss"),
                        a.Name,
                        a.Repeat
                    );
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AlarmEditDialog form = new AlarmEditDialog();

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Alarms 
                    (AlarmTime, IsActive, RepeatDaily, Label, CreatedDate) 
                    VALUES (@time, @active, @repeat, @label, GETDATE())";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@time", form.AlarmTime.TimeOfDay);
                    cmd.Parameters.AddWithValue("@active", form.IsActive);
                    cmd.Parameters.AddWithValue("@repeat", form.Repeat);
                    cmd.Parameters.AddWithValue("@label", form.AlarmName);

                    cmd.ExecuteNonQuery();
                }

                LoadAlarms();
            }
        }

        private void AlarmForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int index = dataGridView1.CurrentRow.Index;
            Alarm alarm = alarms[index];

            AlarmEditDialog form = new AlarmEditDialog(alarm);

            if (form.ShowDialog() == DialogResult.OK)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE Alarms 
                    SET AlarmTime=@time, IsActive=@active, RepeatDaily=@repeat, Label=@label 
                    WHERE Id=@id";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@time", form.AlarmTime.TimeOfDay);
                    cmd.Parameters.AddWithValue("@active", form.IsActive);
                    cmd.Parameters.AddWithValue("@repeat", form.Repeat);
                    cmd.Parameters.AddWithValue("@label", form.AlarmName);
                    cmd.Parameters.AddWithValue("@id", alarm.Id);

                    cmd.ExecuteNonQuery();
                }

                LoadAlarms();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int index = dataGridView1.CurrentRow.Index;
            Alarm alarm = alarms[index];

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Alarms WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", alarm.Id);

                cmd.ExecuteNonQuery();
            }

            LoadAlarms();
        }

        private void buttonDelay_Click(object sender, EventArgs e)
        {
            if (!isRinging || currentAlarm == null) return;

            currentAlarm.Time = currentAlarm.Time.AddMinutes(5);

            StopAlarm("Будильник отложен!");
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            if (!isRinging) return;

            StopAlarm("Будильник выключен!");

            if (!currentAlarm.Repeat)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE Alarms SET IsActive=0 WHERE Id=@id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", currentAlarm.Id);

                    cmd.ExecuteNonQuery();
                }
            }

            LoadAlarms();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            labelDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", new CultureInfo("ru-RU"));

            if (isRinging) return;

            foreach (var alarm in alarms)
            {
                if (alarm.IsActive &&
                    DateTime.Now.Hour == alarm.Time.Hour &&
                    DateTime.Now.Minute == alarm.Time.Minute &&
                    DateTime.Now.Second == alarm.Time.Second)
                {
                    StartAlarm(alarm);
                    break;
                }
            }
        }
    }
}
