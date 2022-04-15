using System.Collections.Generic;
using System.Configuration;
using System.IO;
using ReflectionApp.Sdk;
using ReflectionApp.Sdk.Attributes;

namespace ConfigPlugin
{
    public abstract class ConfigurationProviderBase : IConfigurationProvider
    {
        public Dictionary<string, string> ReadAllSettings()
        {
            var settings = new Dictionary<string, string>();
            var type = GetType();
            foreach (var property in type.GetProperties())
            {
                int lineNumber = 0;
                foreach (var attributeOfProperty in property.GetCustomAttributes(false))
                {
                    if (attributeOfProperty is ConfigurationManagerAttribute configManagerItem)
                        settings.Add(configManagerItem.SettingName, ConfigurationManager.AppSettings[configManagerItem.SettingName]);
                    else if (attributeOfProperty is FileConfigurationAttribute fileConfigItem)
                    {
                        using (StreamReader reader = new StreamReader(fileConfigItem.PathToSettingsFile))
                        {
                            string line = reader.ReadLine();
                            for (int i = 0; i < lineNumber; i++)
                                line = reader.ReadLine();
                            lineNumber++;

                            var lineKeyValue = line?.Split(':');
                            if (lineKeyValue?.Length == 2)
                                settings.Add(fileConfigItem.SettingName, lineKeyValue[1]);
                        }
                    }
                }
            }

            return settings;
        }

        public string ReadSetting(string key)
        {
            var type = GetType();
            foreach (var property in type.GetProperties())
            {
                foreach (var attributeOfProperty in property.GetCustomAttributes(false))
                {
                    if (attributeOfProperty is ConfigurationManagerAttribute configManagerItem && key == configManagerItem.SettingName)
                        return ConfigurationManager.AppSettings[key];
                    else if (attributeOfProperty is FileConfigurationAttribute fileConfigItem && key == fileConfigItem.SettingName)
                    {
                        using (StreamReader reader = new StreamReader(fileConfigItem.PathToSettingsFile))
                        {
                            string line = string.Empty;
                            while ((line = reader.ReadLine()) != null)
                            {
                                var lineKeyValue = line?.Split(':');
                                if (lineKeyValue?.Length == 2)
                                    if (lineKeyValue[0] == key)
                                        return lineKeyValue[1];
                            }
                        }
                    }
                }
            }

            return "Setting not found!";
        }

        public void AddSetting(string key, string value)
        {
            var type = GetType();
            foreach (var property in type.GetProperties())
            {
                foreach (var attributeOfProperty in property.GetCustomAttributes(false))
                {
                    if (attributeOfProperty is FileConfigurationAttribute fileConfigItem)
                        WriteToConfig(key, value, fileConfigItem);
                    else if (attributeOfProperty is ConfigurationManagerAttribute configManagerItem)
                        WriteToConfig(key, value, configManagerItem);
                }
            }
        }

        private static void WriteToConfig(string key, string value, ConfigurationManagerAttribute configManagerItem)
        {
            if (key != configManagerItem.SettingName)
                return;

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            if (settings[key] == null)
                settings.Add(key, value);
            else settings[key].Value = value;

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        private void WriteToConfig(string key, string value, FileConfigurationAttribute fileConfigItem)
        {
            if (key != fileConfigItem.SettingName)
                return;

            string newFileData = string.Empty;
            using (StreamReader reader = new StreamReader(fileConfigItem.PathToSettingsFile))
            {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    var lineKeyValue = line?.Split(':');
                    if (lineKeyValue?.Length == 2 && lineKeyValue[0] == key)
                        newFileData += $"{key}:{value}\n";
                    else newFileData += $"{lineKeyValue[0]}:{lineKeyValue[1]}\n";
                }
            }

            if (!File.Exists(fileConfigItem.PathToSettingsFile))
                File.Create(fileConfigItem.PathToSettingsFile);

            using (StreamWriter writer = new StreamWriter(fileConfigItem.PathToSettingsFile, false))
            {
                writer.Write(newFileData);
            }
        }
    }
}
