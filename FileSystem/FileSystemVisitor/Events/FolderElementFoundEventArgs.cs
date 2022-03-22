using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitorLibrary.Events
{
    public class FolderElementFoundEventArgs<TElement>
    {
        public FolderElementFoundEventArgs(TElement folderElement, IEnumerable<TElement> folderElementQuery)
        {
            FolderElement = folderElement;
            FolderElementQuery = folderElementQuery;
        }

        protected TElement FolderElement { get; set; }

        protected IEnumerable<TElement> FolderElementQuery { get; set; }
    }
}
