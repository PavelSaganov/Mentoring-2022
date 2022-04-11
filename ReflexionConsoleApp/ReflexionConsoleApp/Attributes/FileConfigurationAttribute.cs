using System;
using System.IO;

namespace ReflexionConsoleApp.Attributes
{
    public class FileConfigurationAttribute : Attribute
    {

        public FileConfigurationAttribute(string settingName)
        {
            SettingName = settingName;
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

        public string SettingName { get; set; }
    }
}
