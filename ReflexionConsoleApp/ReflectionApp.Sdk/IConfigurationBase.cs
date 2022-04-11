using System;
using System.Collections.Generic;

namespace ReflectionApp.Sdk
{
    public interface IConfigurationBase
    {
        public Dictionary<string, string> ReadAllSettings();

        public KeyValuePair<string, string> ReadSetting(string key);

        public void AddSetting(string key, string value);
    }
}
