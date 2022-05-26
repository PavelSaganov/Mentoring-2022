using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using StorageLibrary.Model;

namespace StorageLibrary.Repositories.JsonRepository
{
    public class JsonBookRepository : IJsonDocumentRepository<Book>
    {
        public void Create(Book entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            File.WriteAllText($"Book_#{entity.ISBN}", json);
        }

        public Book Read(int uniqueId)
        {
            using (StreamReader r = new StreamReader($"Book_#{uniqueId}.json"))
            {
                string json = r.ReadToEnd();
                var item = JsonConvert.DeserializeObject<Book>(json);
                return item;
            }
        }
    }
}
