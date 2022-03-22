using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemVisitorLibrary.CustomCollections
{
    public class CustomInfoCollection<T> : IEnumerable<T>
    {
        public CustomInfoCollection(IEnumerable<T> elements)
        {
            Elements = elements;
        }

        public IEnumerable<T> Elements { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in Elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
