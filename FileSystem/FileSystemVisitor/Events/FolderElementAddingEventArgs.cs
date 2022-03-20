using System;

namespace FileSystemVisitorLibrary.Events
{
    public class FolderElementAddingEventArgs : EventArgs
    {
        public string ElementName { get; set; }

        public int CountOfElements { get; }

        public bool AbortRequested { get; set; }

        public bool ExcludeRequested { get; set; }

        public FolderElementAddingEventArgs(string elementName, int countOfElements, bool excludeRequested, bool abortRequested)
        {
            ElementName = elementName;
            CountOfElements = countOfElements;
            ExcludeRequested = excludeRequested;
            AbortRequested = abortRequested;
        }
    }
}
