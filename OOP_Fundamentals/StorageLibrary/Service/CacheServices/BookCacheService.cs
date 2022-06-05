using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StorageLibrary.Model;

namespace StorageLibrary.Service.CacheServices
{
    public class BookCacheService : CacheService<Book>
    {
        public BookCacheService()
        {
            _timeToLiveInSeconds = 0;
        }

        public BookCacheService(int timeToLiveInSeconds) 
            : base(timeToLiveInSeconds)
        { }
    }
}
