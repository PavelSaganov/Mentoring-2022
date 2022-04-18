using ReflectionApp.Sdk.Attributes;
using ReflectionApp.Sdk.PluginEnums;

namespace ConfigPlugin
{
    public class FileManagerProvider : ConfigurationProviderBase
    {
        // Random properties without any sense

        [FileConfiguration("CountOfThreads", ConfigProvider.FileProfider)]
        public int CountOfThreads { get; set; }

        [FileConfiguration("MainThreadName", ConfigProvider.FileProfider)]
        public string MainThreadName { get; set; }
    }
}
