namespace SerializationLibrary.Serializers.FileSerializers
{
    public interface IFileSerializer
    {
        public void Serialize<T>(string filePath, T obj);
        public T Deserialize<T>(string filePath);
    }
}
