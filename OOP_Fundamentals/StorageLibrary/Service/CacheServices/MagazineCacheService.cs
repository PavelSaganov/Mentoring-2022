using System.Collections.Generic;
using StorageLibrary.Model;

namespace StorageLibrary.Service.CacheServices
{
    public class MagazineCacheService : ICacheService<Magazine>
    {
        private readonly int _timeToLiveInSeconds = 0;

        public MagazineCacheService()
        { }

        public MagazineCacheService(int timeToLiveInSeconds)
        {
            _timeToLiveInSeconds = timeToLiveInSeconds;
        }

        Dictionary<object, Magazine> _cache = new Dictionary<object, Magazine>();

        public Magazine GetOrCreate(object key, Magazine createItem = null)
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
