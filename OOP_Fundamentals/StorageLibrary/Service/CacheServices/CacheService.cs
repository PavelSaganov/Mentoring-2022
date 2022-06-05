using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StorageLibrary.Service.CacheServices
{
    public class CacheService<T> : ICacheService<T>
    {
        protected int _timeToLiveInSeconds;

        public CacheService()
        {
            _timeToLiveInSeconds = 60;
        }

        public CacheService(int timeToLiveInSeconds)
        {
            _timeToLiveInSeconds = timeToLiveInSeconds;
        }

        Dictionary<object, T> _cache = new Dictionary<object, T>();

        public T GetOrCreate(object key, T createItem)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = createItem;
                if (_timeToLiveInSeconds > 0)
                {
                    Task.Run(() => Remove(key));
                }
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
