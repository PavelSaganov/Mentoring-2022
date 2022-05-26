using System;
using System.Collections.Generic;
using System.Linq;
using StorageLibrary.Model;

namespace StorageLibrary.Service
{
    public class BookService : IDocumentService<Book>
    {
        public IEnumerable<Book> Find(Predicate<Book> searchCondition, IEnumerable<Book> listToSearch)
        {
            return listToSearch.Where(element => searchCondition(element));
        }
    }
}
