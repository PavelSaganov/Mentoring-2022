using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StorageLibrary.Model;

namespace StorageLibrary.Service.CacheServices
{
    public class BookCacheService : ICacheService<Book>
    {
        private readonly int _timeToLiveInSeconds = 60;

        public BookCacheService()
        { }

        public BookCacheService(int timeToLiveInSeconds)
        {
            _timeToLiveInSeconds = timeToLiveInSeconds;
        }

        Dictionary<object, Book> _cache = new Dictionary<object, Book>();

        public Book GetOrCreate(object key, Book createItem = null)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = createItem;
                Task.Run(() => Remove(key));
            }
            return _cache[key];
        }

        public void Remove(object key)
        {
            Thread.Sleep(1000 * _timeToLiveInSeconds);
            _cache.Remove(key);
        }
    }
}
