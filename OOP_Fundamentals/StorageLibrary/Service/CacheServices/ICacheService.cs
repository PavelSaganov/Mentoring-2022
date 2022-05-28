namespace StorageLibrary.Service.CacheServices
{
    public interface ICacheService<TItem>
    {
        public TItem GetOrCreate(object key, TItem createItem);
        public void Remove(object key);
    }
}
