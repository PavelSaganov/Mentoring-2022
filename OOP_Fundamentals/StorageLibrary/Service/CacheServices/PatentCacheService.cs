using System.Collections.Generic;
using StorageLibrary.Model;

namespace StorageLibrary.Service.CacheServices
{
    public class PatentCacheService : ICacheService<Patent>
    {
        private readonly int _timeToLiveInSeconds = 0;

        public PatentCacheService()
        { }

        public PatentCacheService(int timeToLiveInSeconds)
        {
            _timeToLiveInSeconds = timeToLiveInSeconds;
        }

        Dictionary<object, Patent> _cache = new Dictionary<object, Patent>();

        public Patent GetOrCreate(object key, Patent createItem = null)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = createItem;
            }
            return _cache[key];
        }

        public void Remove(object key)
        {
            _cache.Remove(key);
        }
    }
}
