using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using StorageLibrary.Model;

namespace StorageLibrary.Repositories.JsonRepository
{
    public class JsonPatentRepository : IJsonDocumentRepository<Patent>
    {
        public void Create(Patent entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            File.WriteAllText($"Patent_#{entity.Id}", json);
        }

        public Patent Read(int uniqueId)
        {
            using (StreamReader r = new StreamReader($"Patent_#{uniqueId}.json"))
            {
                string json = r.ReadToEnd();
                var item = JsonConvert.DeserializeObject<Patent>(json);
                return item;
            }
        }
    }
}
