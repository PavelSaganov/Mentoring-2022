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
            var typeName = typeof(TEntity).Name;
            if (typeName.Contains('`')) typeName = typeName.Substring(0, typeName.IndexOf("`"));

            var json = JsonConvert.SerializeObject(entity);
            File.WriteAllText($"{typeName}_#{entity.Id}.json", json);
        }

        public TEntity Read(int uniqueId)
        {
            var typeName = typeof(TEntity).Name;
            if (typeName.Contains('`')) typeName = typeName.Substring(0, typeName.IndexOf("`"));

            using (StreamReader r = new StreamReader($"{typeName}_#{uniqueId}.json"))
            {
                string json = r.ReadToEnd();
                var item = JsonConvert.DeserializeObject<TEntity>(json);
                return item;
            }
        }
    }
}
