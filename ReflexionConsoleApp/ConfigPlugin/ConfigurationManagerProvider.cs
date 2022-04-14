using System;
using ReflectionApp.Sdk.Attributes;

namespace ConfigPlugin
{
    public class ConfigurationManagerProvider : ConfigurationProviderBase
    {
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
