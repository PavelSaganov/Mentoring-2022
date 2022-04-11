using ReflexionConsoleApp.Attributes;

namespace ReflexionConsoleApp.Configuration
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
