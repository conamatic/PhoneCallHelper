using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneCallHelper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            File.AppendAllText(Application.StartupPath + "\\log.txt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - Args: " + String.Join(" ", args) + Environment.NewLine);

            if (args.Length == 3)
            {
                File.AppendAllText(Application.StartupPath + "\\log.txt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - " + "3 args received" + Environment.NewLine);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                SettingsHandler _settings = new SettingsHandler();
                SqlHandler _sql = new SqlHandler();

                List<SettingData> settings = _settings.GetModuleSettings();

                _sql.SERVER = _settings.GetSetting(settings, "CallLog_Server");
                _sql.DATABASE = _settings.GetSetting(settings, "CallLog_Database");
                _sql.USERNAME = _settings.GetSetting(settings, "CallLog_Username");
                _sql.PASSWORD = _settings.GetSetting(settings, "CallLog_Password");

                File.AppendAllText(Application.StartupPath + "\\log.txt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - " + _sql.SERVER + " " + _sql.DATABASE + " " + _sql.USERNAME + " " + _sql.PASSWORD + " " + Environment.NewLine);

                if (_sql.TestConnection())
                {
                    File.AppendAllText(Application.StartupPath + "\\log.txt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - " + "Connection to DB Working" + Environment.NewLine);
                    Application.Run(new MainForm(_settings, _sql, args[1], args[2]));
                }
            }
        }
    }
}
