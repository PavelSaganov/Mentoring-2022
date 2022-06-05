using System.IO;
using Newtonsoft.Json;
using StorageLibrary.Model;

namespace StorageLibrary.Repositories.JsonRepository
{
    public class JsonDocumentRepository<TEntity> : IStorageRepository<TEntity>
        where TEntity : AbstractDocument
    {
        public void Create(TEntity entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            File.WriteAllText($"${nameof(TEntity)}_#{entity.Id}", json);
        }

        public TEntity Read(int uniqueId)
        {
            using (StreamReader r = new StreamReader($"{nameof(TEntity)}_#{uniqueId}.json"))
            {
                string json = r.ReadToEnd();
                var item = JsonConvert.DeserializeObject<TEntity>(json);
                return item;
            }
        }
    }
}
