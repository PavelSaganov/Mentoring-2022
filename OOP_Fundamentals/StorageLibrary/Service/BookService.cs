using System;
using System.Collections.Generic;
using System.Linq;
using StorageLibrary.Model;
using StorageLibrary.Repositories;
using StorageLibrary.Repositories.JsonRepository;
using StorageLibrary.Service.CacheServices;

namespace StorageLibrary.Service
{
    public class BookService : IDocumentService<Book>
    {
        private readonly IStorageRepository<Book> _storageRepository;
        private readonly ICacheService<Book> _cacheService;

        public BookService(IStorageRepository<Book> storageRepository, ICacheService<Book> cacheService)
        {
            _storageRepository = storageRepository;
            _cacheService = cacheService;
        }

        public IEnumerable<Book> Find(Predicate<Book> searchCondition, IEnumerable<Book> listToSearch)
        {
            return listToSearch.Where(element => searchCondition(element));
        }

        public void Create(Book entity)
        {
            _storageRepository.Create(entity);
            _cacheService.GetOrCreate($"Book-{entity.ISBN}", entity);
        }

        public Book Read(int uniqueId)
        {
            var storedInCache = _cacheService.GetOrCreate($"Book-{uniqueId}", null);
            if (storedInCache != null)
                return storedInCache;

            return _storageRepository.Read(uniqueId);
        }
    }
}
