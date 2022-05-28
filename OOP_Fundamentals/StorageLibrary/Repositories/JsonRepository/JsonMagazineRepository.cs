using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using StorageLibrary.Model;

namespace StorageLibrary.Repositories.JsonRepository
{
    public class JsonMagazineRepository : IJsonDocumentRepository<Magazine>
    {
        public void Create(Magazine entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            File.WriteAllText($"Magazine_#{entity.ReleaseNumber}", json);
        }

        public Magazine Read(int uniqueId)
        {
            using (StreamReader r = new StreamReader($"Magazine_#{uniqueId}.json"))
            {
                string json = r.ReadToEnd();
                var item = JsonConvert.DeserializeObject<Magazine>(json);
                return item;
            }
        }
    }
}
