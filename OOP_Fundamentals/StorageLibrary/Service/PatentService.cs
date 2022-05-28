using System;
using System.Collections.Generic;
using System.Linq;
using StorageLibrary.Model;
using StorageLibrary.Repositories;
using StorageLibrary.Service.CacheServices;

namespace StorageLibrary.Service
{
    public class PatentService : IDocumentService<Patent>
    {
        private readonly IStorageRepository<Patent> _storageRepository;
        private readonly ICacheService<Patent> _cacheService;

        public PatentService(IStorageRepository<Patent> storageRepository, ICacheService<Patent> cacheService)
        {
            _storageRepository = storageRepository;
            _cacheService = cacheService;
        }

        public IEnumerable<Patent> Find(Predicate<Patent> searchCondition, IEnumerable<Patent> listToSearch)
        {
            return listToSearch.Where(element => searchCondition(element));
        }

        public void Create(Patent entity)
        {
            _storageRepository.Create(entity);
            _cacheService.GetOrCreate($"Patent-{entity.Id}", entity);
        }

        public Patent Read(int uniqueId)
        {
            var storedInCache = _cacheService.GetOrCreate($"Patent-{uniqueId}", null);
            if (storedInCache != null)
                return storedInCache;

            return _storageRepository.Read(uniqueId);
        }
    }
}
