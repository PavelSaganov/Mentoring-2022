using System.IO;
using Newtonsoft.Json;
using StorageLibrary.Model;

namespace StorageLibrary.Repositories.JsonRepository
{
    public class JsonLocalizedBookRepository : IJsonDocumentRepository<LocalizedBook>
    {
        public void Create(LocalizedBook entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            File.WriteAllText($"LocalizedBook_#{entity.ISBN}", json);
        }

        public LocalizedBook Read(int uniqueId)
        {
            using (StreamReader r = new StreamReader($"LocalizedBook_#{uniqueId}.json"))
            {
                string json = r.ReadToEnd();
                var item = JsonConvert.DeserializeObject<LocalizedBook>(json);
                return item;
            }
        }
    }
}
