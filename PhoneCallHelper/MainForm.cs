using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneCallHelper
{
    public partial class MainForm : Form
    {
        Timer tmr = new Timer();
        SettingsHandler _settings;
        SqlHandler _sql;
        string phoneNo;
        string duration;

        public MainForm(SettingsHandler set, SqlHandler sql, string phone, string dur)
        {
            InitializeComponent();

            int x = Screen.PrimaryScreen.WorkingArea.Width - 5 - this.Size.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - 5 - this.Size.Height;
            this.Location = new Point(x, y);

            tmr.Interval = 5000;
            tmr.Tick += CloseForm;
            tmr.Start();

            _settings = set;
            _sql = sql;
            phoneNo = phone;
            duration = dur;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string start_time = dt.AddSeconds(-Convert.ToDouble(duration)).ToString("yyyy-MM-dd hh:mm:ss");
            string end_time = dt.ToString("yyyy-MM-dd hh:mm:ss");
            string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            username = username.Split('\\')[1].Split('.')[0].ToUpper();
            _sql.Command("INSERT INTO Flexpoint.CALLS (user_nm, phone_no, duration, start_time, end_time) VALUES ('" + username + "','" + phoneNo + "','" + duration + "','" + start_time + "','" + end_time + "')");

            TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(duration));
            string durationStr = time.ToString(@"hh\h\ mm\m\ ss\s");

            lblDuration.Text = lblDuration.Text.Replace("###", durationStr);
            lblPhoneNo.Text = lblPhoneNo.Text.Replace("###", phoneNo);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            tmr.Stop();
            this.Close();
        }
    }
}
