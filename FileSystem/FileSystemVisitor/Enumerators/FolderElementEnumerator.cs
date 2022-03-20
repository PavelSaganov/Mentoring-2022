namespace FileSystemVisitorLibrary.Enumerators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    class FolderElementEnumerator : IEnumerator
    {
        private readonly string[] fileNames;
        private int position = -1;

        public FolderElementEnumerator(string[] fileNames) => this.fileNames = fileNames;

        public object Current
        {
            get
            {
                if (position == -1 || position >= fileNames.Length)
                    throw new ArgumentException();
                return fileNames[position];
            }
        }

        public bool MoveNext()
        {
            if (position < fileNames.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset() => position = -1;
    }
}
