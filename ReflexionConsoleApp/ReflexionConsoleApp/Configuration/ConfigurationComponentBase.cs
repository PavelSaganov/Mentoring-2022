using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ReflectionApp.Sdk;
using ReflectionApp.Sdk.Attributes;
namespace ReflexionConsoleApp.Configuration
{
    public abstract class ConfigurationComponentBase
    {
        private readonly IConfigurationProvider _configurationProvider;

        public ConfigurationComponentBase(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public void AddSetting(string key, string value)
        {
            _configurationProvider?.AddSetting(key, value);
        }

        public string ReadSetting(string key)
        {
            return _configurationProvider?.ReadSetting(key);
        }
    }
}
