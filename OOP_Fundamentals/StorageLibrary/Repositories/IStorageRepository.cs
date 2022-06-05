namespace StorageLibrary.Repositories
{
    public interface IStorageRepository<TEntity>
    {
        public void Create(TEntity entity);
        public TEntity Read(int uniqueId);
    }
}
