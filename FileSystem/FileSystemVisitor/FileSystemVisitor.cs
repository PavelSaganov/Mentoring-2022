using FileSystemVisitorLibrary.Events;
using System;
using System.Collections;
using System.IO;

namespace FileSystemVisitorLibrary
{
    public class FileSystemVisitor : IEnumerable
    {
        private string PathToFolder { get; set; }

        private event EventHandler<FolderElementAddingEventArgs> NewFolderElement;
        private event EventHandler StartSearch;
        private event EventHandler EndSearch;

        public ArrayList ElementsOfFolder { get; set; }

        public FileSystemVisitor(string pathToFolder)
        {
            ElementsOfFolder = new ArrayList();
            PathToFolder = pathToFolder;

            // Events
            StartSearch += OnStartFilter;
            EndSearch += OnEndFilter;
            NewFolderElement += OnElementAdding;

            // Search and add folder elements
            StartSearch?.Invoke(this, new EventArgs());
            AddFindedFolderElements();
            EndSearch?.Invoke(this, new EventArgs());
        }

        public FileSystemVisitor(string pathToFolder, Action<ArrayList> actionToFilter) : this(pathToFolder)
        {
            actionToFilter.Invoke(ElementsOfFolder);
        }

        private void AddFindedFolderElements()
        {
            var allElements = GetElementsOfFolder();
            for (int elementNumber = 0; elementNumber < allElements.Length; elementNumber++)
                NewFolderElement?.Invoke(this, new FolderElementAddingEventArgs(allElements[elementNumber], elementNumber, false, false));
        }

        private void OnStartFilter(object sender, EventArgs e)
        {
            Console.WriteLine("Search is starting...");
        }

        private void OnEndFilter(object sender, EventArgs e)
        {
            Console.WriteLine("Search ended...");
        }

        private void OnElementAdding(object sender, FolderElementAddingEventArgs e)
        {
            if (e.AbortRequested && e.CountOfElements == 3)
            {
                if (ElementsOfFolder.Count > 0)
                    ElementsOfFolder.Clear();
                Console.WriteLine($"Adding aborted since count of elements > {3}");
            }
            else if (!(e.ExcludeRequested && e.CountOfElements > 3))
            {
                ElementsOfFolder.Add(e.ElementName);
                Console.WriteLine($"Added new folder element: {e.ElementName}");
            }
        }

        private string[] GetElementsOfFolder()
        {
            return Directory.GetFileSystemEntries(PathToFolder);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var element in ElementsOfFolder)
            {
                yield return element;
            }
        }
    }
}
