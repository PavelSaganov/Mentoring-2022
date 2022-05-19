using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationLibrary.Serializers.FileSerializers
{
    public class BinaryFileSerializer : IFileSerializer
    {
        private BinaryFormatter binSerializer;

        public T Deserialize<T>(string filePath)
        {
            binSerializer = new BinaryFormatter();
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var resultOfDeserialization = binSerializer.Deserialize(fs);
                if ((T)resultOfDeserialization != null)
                {
                    var result = (T)resultOfDeserialization;
                    return result;
                }

                throw new FormatException($"Cannot map to {typeof(T)}");
            }
        }

        public void Serialize<T>(string filePath, T obj)
        {
            binSerializer = new BinaryFormatter();

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                binSerializer.Serialize(fs, obj);
            }
        }
    }
}
