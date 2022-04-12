using ReflectionApp.Sdk.Attributes;

namespace ReflexionConsoleApp.Configuration__In_dll_
{
    public class FileManagerProvider : ConfigurationComponentBase
    {
        // Random properties without any sense

        [FileConfiguration("CountOfThreads")]
        public int CountOfThreads { get; set; }

        [FileConfiguration("MainThreadName")]
        public string MainThreadName { get; set; }
    }
}
