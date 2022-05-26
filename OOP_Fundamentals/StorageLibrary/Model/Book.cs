using System;
using System.Collections.Generic;

namespace StorageLibrary.Model
{
    public class Book : AbstractDocument
    {
        public int ISBN { get => Id; set { Id = value; } }
        public string Title { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
