using System.Collections.Generic;
using System.Configuration;
using System.IO;
using ReflectionApp.Sdk;
using ReflectionApp.Sdk.Attributes;

namespace ConfigurationPlagin
{
    public abstract class ConfigurationComponentBase : IConfigurationBase
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

        public KeyValuePair<string, string> ReadSetting(string key)
        {
            var type = GetType();
            foreach (var property in type.GetProperties())
            {
                foreach (var attributeOfProperty in property.GetCustomAttributes(false))
                {
                    if (attributeOfProperty is ConfigurationManagerAttribute configManagerItem && key == configManagerItem.SettingName)
                        return new KeyValuePair<string, string>(key, ConfigurationManager.AppSettings[key]);
                    else if (attributeOfProperty is FileConfigurationAttribute fileConfigItem && key == fileConfigItem.SettingName)
                    {
                        using (StreamReader reader = new StreamReader(fileConfigItem.PathToSettingsFile))
                        {
                            string line = reader.ReadToEnd();
                            var lineKeyValue = line?.Split(':');
                            if (lineKeyValue?.Length == 2)
                                return new KeyValuePair<string, string>(lineKeyValue[0], lineKeyValue[1]);
                        }
                    }
                }
            }

            return new KeyValuePair<string, string>();
        }

        public void AddSetting(string key, string value)
        {
            var type = GetType();
            foreach (var property in type.GetProperties())
            {
                foreach (var attributeOfProperty in property.GetCustomAttributes(false))
                {
                    if (attributeOfProperty is ConfigurationManagerAttribute && attributeOfProperty is FileConfigurationAttribute)
                    {
                        WriteToConfig(key, value, attributeOfProperty as ConfigurationManagerAttribute);
                        WriteToConfig(key, value, attributeOfProperty as FileConfigurationAttribute);
                    }
                    else if (attributeOfProperty is FileConfigurationAttribute fileConfigItem)
                        WriteToConfig(key, value, fileConfigItem);
                    else if (attributeOfProperty is ConfigurationManagerAttribute configManagerItem)
                        WriteToConfig(key, value, configManagerItem);
                }
            }
        }

        private static void WriteToConfig(string key, string value, ConfigurationManagerAttribute configManagerItem)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            // if setting with this name exists
            if (settings[configManagerItem.SettingName] == null)
                settings.Add(configManagerItem.SettingName, value);
            else
                settings[configManagerItem.SettingName].Value = value;

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        private void WriteToConfig(string key, string value, FileConfigurationAttribute fileConfigItem)
        {
            var settings = ReadAllSettings();
            if (!File.Exists(fileConfigItem.PathToSettingsFile))
                File.Create(fileConfigItem.PathToSettingsFile);

            using (StreamWriter writer = new StreamWriter(fileConfigItem.PathToSettingsFile, false))
            {
                foreach (var keyValue in settings)
                {
                    if (key == keyValue.Key)
                        writer.WriteLine($"{keyValue.Key}:{value}");
                    else writer.WriteLine($"{keyValue.Key}:{keyValue.Value}");
                }
            }
        }
    }
}
