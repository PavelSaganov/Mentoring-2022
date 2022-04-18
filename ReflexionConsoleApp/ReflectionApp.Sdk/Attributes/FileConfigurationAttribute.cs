using System;
using System.IO;
using ReflectionApp.Sdk.PluginEnums;

namespace ReflectionApp.Sdk.Attributes
{
    public class FileConfigurationAttribute : Attribute
    {
        public FileConfigurationAttribute(string settingName, ConfigProvider provider)
        {
            SettingName = settingName;
            Provider = provider;
        }

        // Path to settings file is hardcoded
        public string PathToSettingsFile
        {
            get
            {
                string workingDirectory = Directory.GetCurrentDirectory();
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;
                return $"{projectDirectory}\\settings.txt";
            }
        }

        public ConfigProvider Provider { get; set; }

        public string SettingName { get; set; }
    }
}
