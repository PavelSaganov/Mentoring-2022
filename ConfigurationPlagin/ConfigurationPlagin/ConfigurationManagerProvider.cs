using System;
using ReflectionApp.Sdk.Attributes;

namespace ConfigurationPlagin
{
    public class ConfigurationManagerProvider : ConfigurationComponentBase
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
