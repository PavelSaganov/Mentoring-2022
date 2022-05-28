using System;
using System.Collections.Generic;
using System.Linq;
using StorageLibrary.Model;
using StorageLibrary.Repositories;
using StorageLibrary.Service.CacheServices;

namespace StorageLibrary.Service
{
    public class MagazineService : IDocumentService<Magazine>
    {
        private readonly IStorageRepository<Magazine> _storageRepository;
        private readonly ICacheService<Magazine> _cacheService;

        public MagazineService(IStorageRepository<Magazine> storageRepository, ICacheService<Magazine> cacheService)
        {
            _storageRepository = storageRepository;
            _cacheService = cacheService;
        }

        public IEnumerable<Magazine> Find(Predicate<Magazine> searchCondition, IEnumerable<Magazine> listToSearch)
        {
            return listToSearch.Where(element => searchCondition(element));
        }

        public void Create(Magazine entity)
        {
            _storageRepository.Create(entity);
            _cacheService.GetOrCreate($"Magazine-{entity.ReleaseNumber}", entity);
        }

        public Magazine Read(int uniqueId)
        {
            var storedInCache = _cacheService.GetOrCreate($"Magazine-{uniqueId}", null);
            if (storedInCache != null)
                return storedInCache;

            return _storageRepository.Read(uniqueId);
        }
    }
}
