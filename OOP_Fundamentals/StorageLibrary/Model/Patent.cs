using System;
using System.Collections.Generic;

namespace StorageLibrary.Model
{
    public class Patent : AbstractDocument
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public DateTime DatePublished { get; set; }
        public DateTime ExpirationDate { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}" +
                $" Title = {Title}" +
                $" DatePublished = {DatePublished.ToShortDateString()}" +
                $" ExpirationDate = {ExpirationDate.ToShortDateString()}";
        }
    }
}
