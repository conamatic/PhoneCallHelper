using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneCallHelper
{
    public class SettingsHandler
    {
        public List<SettingData> GetModuleSettings()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            List<SettingData> moduleSettings = new List<SettingData>();

            if (File.Exists("settings.json"))
            {
                moduleSettings = JsonConvert.DeserializeObject<List<SettingData>>(File.ReadAllText("settings.json"));
            }

            return moduleSettings;
        }


        public bool SaveModuleSettings(JObject json)
        {
            string path = Application.StartupPath;
            File.Delete(path + "\\settings.json");

            using (StreamWriter file = File.CreateText(path + "\\settings.json"))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                json.WriteTo(writer);
            }

            return File.Exists(path + "\\settings.json");
        }

        public string GetSetting(List<SettingData> settings, string settingName)
        {
            foreach (SettingData sd in settings)
                if (sd.Name == settingName)
                    return sd.Value;

            return "";
        }
    }

    public class SettingData
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Domain { get; set; }
        public string Value { get; set; }

        [JsonIgnore]
        public string Module { get; set; }
    }
}
