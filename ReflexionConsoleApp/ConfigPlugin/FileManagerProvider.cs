using ReflectionApp.Sdk.Attributes;

namespace ConfigPlugin
{
    public class FileManagerProvider : ConfigurationProviderBase
    {
        // Random properties without any sense

        [FileConfiguration("CountOfThreads")]
        public int CountOfThreads { get; set; }

        [FileConfiguration("MainThreadName")]
        public string MainThreadName { get; set; }
    }
}
