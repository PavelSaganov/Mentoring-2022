using FileSystemVisitorLibrary.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FileSystemVisitorLibrary.Model
{
    public class FolderElement /*: IEnumerable*/
    {
        public string Name { get; set; }

        //public IEnumerator GetEnumerator() => new FolderElementEnumerator()
    }
}
