using System;
using System.Collections.Generic;
using System.Text;
using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public class DocumentCreator<T> : IDocumentCreator<T>
        where T : AbstractDocument
    {
        public T Create()
        {
            var type = typeof(T);

            if (type == typeof(Book))
            {
                return new Book() as T;
            }
            if (type == typeof(LocalizedBook))
            {
                return new LocalizedBook() as T;
            }
            if (type == typeof(Patent))
            {
                return new Patent() as T;
            }
            if (type == typeof(Magazine))
            {
                return new Magazine() as T;
            }

            return null;
        }
    }
}
