using System;
using System.Collections.Generic;
using System.Text;
using ReflectionApp.Sdk;
using ReflectionApp.Sdk.PluginEnums;
using ReflexionConsoleApp.ConfigurationPlugins;

namespace ReflexionConsoleApp.PluginSelector
{
    public class ConfigPluginSelector
    {
        public IConfigurationProvider GetConfigurationProvider(ConfigProvider configProvider)
        {
            var configurationPlugins = ConfigurationPlugin.ReadAllPlugins();
            switch (configProvider)
            {
                case ConfigProvider.FileProfider:
                    
                    break;
            }
            return null;
        }
    }
}
