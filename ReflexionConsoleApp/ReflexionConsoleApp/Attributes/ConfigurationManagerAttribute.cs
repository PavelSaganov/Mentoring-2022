using System;
using System.Collections.Generic;
using System.Text;

namespace ReflexionConsoleApp.Attributes
{
    public class ConfigurationManagerAttribute : Attribute
    {
        public string SettingName { get; set; }

        public ConfigurationManagerAttribute(string settingName)
        {
            SettingName = settingName;
        }
    }
}
