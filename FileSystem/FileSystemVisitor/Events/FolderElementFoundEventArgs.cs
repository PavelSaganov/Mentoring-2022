using System;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitorLibrary.Events
{
    public abstract class FolderElementFoundEventArgs<TElement>
    {
        protected FolderElementFoundEventArgs(TElement folderElement, IEnumerable<TElement> folderElementQuery, bool excludeRequires, bool abortRequires)
        {
            FolderElement = folderElement;
            FolderElementQuery = folderElementQuery;
            ExcludeRequires = excludeRequires;
            AbortRequires = abortRequires;
        }

        public TElement FolderElement { get; set; }

        public IEnumerable<TElement> FolderElementQuery { get; set; }

        public bool ExcludeRequires { get; set; }

        public bool AbortRequires { get; set; }
    }
}
