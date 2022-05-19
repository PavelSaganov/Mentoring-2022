using System.IO;
using System.Text.Json;

namespace SerializationLibrary.Serializers.FileSerializers
{
    public class JsonFileSerializer : IFileSerializer
    {
        public T Deserialize<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var result = JsonSerializer.Deserialize<T>(json);
            return result;
        }

        public void Serialize<T>(string filePath, T obj)
        {
            using (var fs = File.OpenWrite(filePath))
            {
                JsonSerializer.Serialize(new Utf8JsonWriter(fs), obj);
            }
        }
    }
}
