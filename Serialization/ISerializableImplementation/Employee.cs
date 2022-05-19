using System;
using System.Runtime.Serialization;

namespace ISerializableImplementation
{
    [Serializable]
    public class Employee : ISerializable
    {
        public Employee()
        {

        }

        public Employee(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name123");
            Age = info.GetInt32("Age555");
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name123", Name);
            info.AddValue("Age555", Age);
        }
    }
}
