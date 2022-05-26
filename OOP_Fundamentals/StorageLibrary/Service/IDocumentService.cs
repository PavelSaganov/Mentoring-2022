using System;
using System.Collections.Generic;
using StorageLibrary.Model;

namespace StorageLibrary.Service
{
    public interface IDocumentService<T>
        where T : IDocumentType
    {
        public IEnumerable<T> Find(Predicate<T> searchCondition, IEnumerable<T> listToSearch);
    }
}
