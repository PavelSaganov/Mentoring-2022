using System;
using System.Collections;
using System.Configuration;

namespace UnitTests.Configuration
{
    public class FileSystemVisitorConfiguration : IConfiguration
    {
        public bool AbortRequested { get; set; }

        public bool ExcludeRequested { get; set; }

        public int CountForAbort { get; set; }

        public int CountForExclude { get; set; }

        public string PpathToFolder { get; set; }

        public Action<ArrayList> actionToFilter { get; set; }

        public FileSystemVisitorConfiguration(string pathToFolder = null)
        {
            PpathToFolder = pathToFolder ?? ConfigurationManager.AppSettings.Get("PathToFolder");
            CountForAbort = int.Parse(ConfigurationManager.AppSettings.Get("CountForAbort"));
            CountForExclude = int.Parse(ConfigurationManager.AppSettings.Get("CountForExclude"));
            AbortRequested = bool.Parse(ConfigurationManager.AppSettings.Get("AbortRequested"));
            ExcludeRequested = bool.Parse(ConfigurationManager.AppSettings.Get("ExcludeRequested"));
        }
    }
}
