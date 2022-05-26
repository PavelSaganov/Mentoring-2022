using System;
using System.Collections.Generic;

namespace StorageLibrary.Model
{
    public class Patent : IDocumentType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public DateTime DatePublished { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
