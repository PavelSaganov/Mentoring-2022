using System;

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
