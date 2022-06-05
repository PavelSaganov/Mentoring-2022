using System.IO;
using Newtonsoft.Json;
using StorageLibrary.Model;

namespace StorageLibrary.Repositories.JsonRepository
{
    public class JsonBookRepository : IJsonDocumentRepository<AbstractDocument>
    {
        public void Create(AbstractDocument entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            var typeOfEntity = entity.GetType();
            var nameOfEntityClass = typeOfEntity.Name;

            File.WriteAllText($"{nameOfEntityClass}_#{entity.Id}", json);
        }

        public AbstractDocument Read(int uniqueId)
        {
            using (StreamReader r = new StreamReader($"Book_#{uniqueId}.json"))
            {
                string json = r.ReadToEnd();
                var item = JsonConvert.DeserializeObject<AbstractDocument>(json);
                return item;
            }
        }
    }
}
