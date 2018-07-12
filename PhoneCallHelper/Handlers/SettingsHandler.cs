using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneCallHelper
{
    public class SettingsHandler
    {
        public List<SettingData> GetModuleSettings()
        {
            string path = Application.StartupPath;
            List<SettingData> moduleSettings = new List<SettingData>();

            if (File.Exists(path + "\\settings.json"))
            {
                JToken tkn = JObject.Parse(File.ReadAllText(path + "\\settings.json"));
                JObject obj = tkn.Value<JObject>();

                foreach (KeyValuePair<string, JToken> setting in obj)
                {
                    JToken token = JObject.Parse(setting.Value.ToString());

                    SettingData settings = new SettingData
                    {
                        Name = (string)token.SelectToken("Name"),
                        Text = (string)token.SelectToken("Text"),
                        Value = (string)token.SelectToken("Value"),
                        Domain = (string)token.SelectToken("Domain"),
                        Module = "PhoneCallHelper"
                    };
                    moduleSettings.Add(settings);
                }

                return moduleSettings;
            }

            return null;
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
        public string Module { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Domain { get; set; }
        public string Value { get; set; }
    }

}
