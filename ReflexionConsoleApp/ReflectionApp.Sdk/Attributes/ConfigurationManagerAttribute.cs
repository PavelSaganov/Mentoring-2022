using System;
using System.Collections.Generic;
using System.Text;
using ReflectionApp.Sdk.PluginEnums;

namespace ReflectionApp.Sdk.Attributes
{
    public class ConfigurationManagerAttribute : Attribute
    {
        public string SettingName { get; set; }

        public ConfigProvider Provider { get; set; }

        public ConfigurationManagerAttribute(string settingName, ConfigProvider provider)
        {
            SettingName = settingName;
            Provider = provider;
        }
    }
}
