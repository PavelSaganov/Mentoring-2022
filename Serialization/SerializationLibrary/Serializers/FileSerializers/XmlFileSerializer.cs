using System;
using System.IO;
using System.Xml.Serialization;

namespace SerializationLibrary.Serializers.FileSerializers
{
    public class XmlFileSerializer : IFileSerializer
    {
        private XmlSerializer xmlSerializer;

        public T Deserialize<T>(string filePath)
        {
            xmlSerializer = new XmlSerializer(typeof(T));
            using (var fs = new StreamReader(filePath))
            {
                var resultOfDeserialization = xmlSerializer.Deserialize(new StringReader(fs.ReadToEnd()));
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
            xmlSerializer = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, obj);
            }
        }
    }
}
