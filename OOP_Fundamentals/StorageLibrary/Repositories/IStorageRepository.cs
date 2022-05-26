using System;
using System.Collections.Generic;
using System.Text;
using StorageLibrary.Model;

namespace StorageLibrary.Repositories
{
    public interface IStorageRepository<TEntity>
    {
        public void Create(TEntity entity);
        public TEntity Read(int uniqueId);
    }
}
