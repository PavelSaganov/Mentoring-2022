using System;
using System.Collections.Generic;
using System.Linq;
using StorageLibrary.Model;
using StorageLibrary.Repositories;
using StorageLibrary.Service.CacheServices;

namespace StorageLibrary.Service
{
    public class LocalizedBookService : IDocumentService<LocalizedBook>
    {
        private readonly IStorageRepository<LocalizedBook> _storageRepository;
        private readonly ICacheService<LocalizedBook> _cacheService;

        public LocalizedBookService(IStorageRepository<LocalizedBook> storageRepository, ICacheService<LocalizedBook> cacheService)
        {
            _storageRepository = storageRepository;
            _cacheService = cacheService;
        }

        public IEnumerable<LocalizedBook> Find(Predicate<LocalizedBook> searchCondition, IEnumerable<LocalizedBook> listToSearch)
        {
            return listToSearch.Where(element => searchCondition(element));
        }

        public void Create(LocalizedBook entity)
        {
            _storageRepository.Create(entity);
            _cacheService.GetOrCreate($"LocalizedBook-{entity.ISBN}", entity);
        }

        public LocalizedBook Read(int uniqueId)
        {
            var storedInCache = _cacheService.GetOrCreate($"LocalizedBook-{uniqueId}", null);
            if (storedInCache != null)
                return storedInCache;

            return _storageRepository.Read(uniqueId);
        }
    }
}
