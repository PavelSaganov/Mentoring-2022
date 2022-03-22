using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitorLibrary.Events
{
    public class DirectoryFoundEventArgs : FolderElementFoundEventArgs<DirectoryInfo>
    {
        public DirectoryFoundEventArgs(DirectoryInfo folderElement, IEnumerable<DirectoryInfo> folderElementQuery, bool excludeRequires = false, bool abortRequires = false)
            : base(folderElement, folderElementQuery, excludeRequires, abortRequires)
        { }
    }
}
