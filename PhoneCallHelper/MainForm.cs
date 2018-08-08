using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
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

            tmr.Interval = 10000;
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
            string start_time = dt.AddSeconds(-Convert.ToDouble(duration)).ToString("yyyy-MM-dd HH:mm:ss");
            string end_time = dt.ToString("yyyy-MM-dd HH:mm:ss");
            string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            username = username.Split('\\')[1].Split('.')[0].ToUpper();
            _sql.Command("INSERT INTO Flexpoint.CALLS (username, phone_no, duration, start_time, end_time) VALUES ('" + username + "','" + phoneNo + "','" + duration + "','" + start_time + "','" + end_time + "')");

            TimeSpan time = TimeSpan.FromSeconds(Convert.ToDouble(duration));
            string durationStr = time.ToString(@"hh\h\ mm\m\ ss\s");

            if (_sql.Select($"SELECT TOP 1 id, company FROM Flexpoint.CONTACT WHERE phone_no = '{phoneNo}'") == null)
            {
                label4.Text = "Contact not found!";

            }
            else
            {

                label4.Text = "Click to create job";
            }


            lblDuration.Text = lblDuration.Text.Replace("###", durationStr);
            lblPhoneNo.Text = lblPhoneNo.Text.Replace("###", phoneNo);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            tmr.Stop();
            this.Close();
        }

        private void CreateLog(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string start_time = dt.AddSeconds(-Convert.ToDouble(duration)).ToString("yyyy-MM-dd HH:mm:ss");
            string end_time = dt.ToString("yyyy-MM-dd HH:mm:ss");
            string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            username = username.Split('\\')[1].Split('.')[0].ToUpper();

            Dictionary<string, string> contact = _sql.Select($"SELECT TOP 1 id, company FROM Flexpoint.CONTACT WHERE phone_no = '{phoneNo}'");


            if (contact != null)
            {
                string id = contact["id"];
                string company = contact["company"];

                int minutes = (int)Math.Round(Convert.ToDouble(duration) / 60);

                Dictionary<string, string> job = _sql.Select($"SELECT id FROM Flexpoint.JOB_LOG WHERE STATUS = 'Opened' AND COMPANY = '{company}' AND CONTACT = {contact["id"]}");

                if (job == null || string.IsNullOrEmpty(job["id"]))
                {
                    _sql.Command("INSERT INTO Flexpoint.JOB_LOG(ASSIGNED_BY, ASSIGNED_TO, CHANGED, COMPANY, CONTACT, DATASYNC, DATASYNCED, EMAIL_COMPLETED, EMAIL_INPROGRESS, EMAIL_OPENED, IS_MERGED, JOB_NOTES, JOB_TIME, STATUS, TIME_OPENED, USERID, Z_INCOMPLETE)" +
                        $"values('{username}', '{username}', '{start_time}', '{company}', '{id}', '{start_time}', '0' ,'0', '0', '0', '0', 'Created from call', '0', 'Opened', '{start_time}', '{username}', '0');");

                    job = _sql.Select($"SELECT id FROM Flexpoint.JOB_LOG WHERE STATUS = 'Opened' AND COMPANY = '{company}' AND CONTACT = {contact["id"]}");

                    _sql.Command("INSERT INTO Flexpoint.JOB_DETAIL(CHANGED, DATASYNC, DATASYNCED, IS_MERGED, USERID, Z_INCOMPLETE, JOB_ID, JOB_TIME, NOTES, USERNAME) " +
                        $"values('{start_time}', '{start_time}', '0', '0', '{username}', '0', '{job["id"]}', '{minutes}', 'Call taken: {phoneNo}', '{username}');");
                }
                else
                {
                    _sql.Command("INSERT INTO Flexpoint.JOB_DETAIL(CHANGED, DATASYNC, DATASYNCED, IS_MERGED, USERID, Z_INCOMPLETE, JOB_ID, JOB_TIME, NOTES, USERNAME) " +
                        $"values('{start_time}', '{start_time}', '0', '0', '{username}', '0', '{job["id"]}', '{minutes}', 'Call taken', '{username}');");
                }
            }
        }
    }
}
