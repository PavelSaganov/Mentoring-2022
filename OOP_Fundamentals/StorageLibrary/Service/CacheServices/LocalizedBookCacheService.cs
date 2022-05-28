using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StorageLibrary.Model;

namespace StorageLibrary.Service.CacheServices
{
    public class LocalizedBookCacheService : ICacheService<LocalizedBook>
    {
        private readonly int _timeToLiveInSeconds = 60;

        public LocalizedBookCacheService()
        { }

        public LocalizedBookCacheService(int timeToLiveInSeconds)
        {
            _timeToLiveInSeconds = timeToLiveInSeconds;
        }

        Dictionary<object, LocalizedBook> _cache = new Dictionary<object, LocalizedBook>();

        public LocalizedBook GetOrCreate(object key, LocalizedBook createItem = null)
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
