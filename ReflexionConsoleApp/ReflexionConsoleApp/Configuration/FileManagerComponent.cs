using ReflectionApp.Sdk;
using ReflectionApp.Sdk.Attributes;

namespace ReflexionConsoleApp.Configuration
{
    public class FileManagerComponent : ConfigurationComponentBase
    {
        public FileManagerComponent(IConfigurationProvider configurationProvider) 
            : base(configurationProvider)
        { }

        // Random properties without any sense

        [FileConfiguration("CountOfThreads")]
        public int CountOfThreads { get; set; }

        [FileConfiguration("MainThreadName")]
        public string MainThreadName { get; set; }
    }
}
