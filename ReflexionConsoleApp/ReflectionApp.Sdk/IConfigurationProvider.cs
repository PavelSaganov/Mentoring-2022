using System;
using System.Collections.Generic;

namespace ReflectionApp.Sdk
{
    public interface IConfigurationProvider
    {
        public Dictionary<string, string> ReadAllSettings();

        public string ReadSetting(string key);

        public void AddSetting(string key, string value);
    }
}
