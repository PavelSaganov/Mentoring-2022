using System;
using System.Collections.Generic;
using StorageLibrary.Model;

namespace StorageLibrary.Service
{
    public interface IDocumentService<T>
        where T : AbstractDocument
    {
        public IEnumerable<T> Find(Predicate<T> searchCondition, IEnumerable<T> listToSearch);
    }
}
