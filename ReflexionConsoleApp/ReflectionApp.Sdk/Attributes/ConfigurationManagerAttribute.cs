using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionApp.Sdk.Attributes
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
