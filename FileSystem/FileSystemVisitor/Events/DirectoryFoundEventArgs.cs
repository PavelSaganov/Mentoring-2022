using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitorLibrary.Events
{
    public class DirectoryFoundEventArgs : FolderElementFoundEventArgs<DirectoryInfo>
    {
        public DirectoryFoundEventArgs(DirectoryInfo folderElement, IEnumerable<DirectoryInfo> folderElementQuery)
            : base(folderElement, folderElementQuery)
        { }
    }
}
