using System;
using ReflectionApp.Sdk;
using ReflectionApp.Sdk.Attributes;

namespace ReflexionConsoleApp.Configuration
{
    public class ConfigurationManagerComponent : ConfigurationComponentBase
    {
        public ConfigurationManagerComponent(IConfigurationProvider configurationProvider)
            : base(configurationProvider)
        { }

        // Random properties without any sense

        [ConfigurationManager("TaskNumber")]
        public int TaskNumber { get; set; }

        [ConfigurationManager("MainUrl")]
        public string MainUrl { get; set; }

        [ConfigurationManager("MaxRandomNumber")]
        public float MaxRandomNumber { get; set; }

        [ConfigurationManager("CookieStoreTime")]
        public TimeSpan CookieStoreTime { get; set; }

    }
}
