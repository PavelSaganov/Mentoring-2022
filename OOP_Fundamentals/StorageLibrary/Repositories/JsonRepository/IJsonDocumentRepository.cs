using StorageLibrary.Model;

namespace StorageLibrary.Repositories.JsonRepository
{
    public interface IJsonDocumentRepository<TEntity> : IStorageRepository<TEntity>
        where TEntity : AbstractDocument
    {
    }
}
