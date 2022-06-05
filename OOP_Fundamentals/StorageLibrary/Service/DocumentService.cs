using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageLibrary.Model;
using StorageLibrary.Repositories;
using StorageLibrary.Service.CacheServices;

namespace StorageLibrary.Service
{
    public class DocumentService<T> : IDocumentService<T>
        where T : AbstractDocument
    {
        private readonly IStorageRepository<T> _storageRepository;
        private readonly ICacheService<T> _cacheService;

        public DocumentService(IStorageRepository<T> storageRepository, ICacheService<T> cacheService)
        {
            _storageRepository = storageRepository;
            _cacheService = cacheService;
        }

        public IEnumerable<T> Find(Predicate<T> searchCondition, IEnumerable<T> listToSearch)
        {
            return listToSearch.Where(element => searchCondition(element));
        }

        public void Create(T entity)
        {
            _storageRepository.Create(entity);
            _cacheService.GetOrCreate($"${nameof(T)}-{entity.Id}", entity);
        }

        public T Read(int uniqueId)
        {
            var storedInCache = _cacheService.GetOrCreate($"{nameof(T)}-{uniqueId}", null);
            if (storedInCache != null)
                return storedInCache;

            return _storageRepository.Read(uniqueId);
        }
    }
}
