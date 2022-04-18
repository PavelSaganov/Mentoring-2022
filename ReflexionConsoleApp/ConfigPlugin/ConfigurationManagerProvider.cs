using System;
using ReflectionApp.Sdk.Attributes;
using ReflectionApp.Sdk.PluginEnums;

namespace ConfigPlugin
{
    public class ConfigurationManagerProvider : ConfigurationProviderBase
    {
        // Random properties without any sense

        [ConfigurationManager("TaskNumber", ConfigProvider.ConfigManagerProvider)]
        public int TaskNumber { get; set; }

        [ConfigurationManager("MainUrl", ConfigProvider.ConfigManagerProvider)]
        public string MainUrl { get; set; }

        [ConfigurationManager("MaxRandomNumber", ConfigProvider.ConfigManagerProvider)]
        public float MaxRandomNumber { get; set; }

        [ConfigurationManager("CookieStoreTime", ConfigProvider.ConfigManagerProvider)]
        public TimeSpan CookieStoreTime { get; set; }
    }
}
