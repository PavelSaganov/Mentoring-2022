using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DeepCloning
{
    public class Cloner
    {
        public T DeepClone<T>(T obj)
        {
            var newInstance = JsonSerializer.Deserialize(JsonSerializer.Serialize(obj, typeof(T)), typeof(T));
            var returnValue = (T)newInstance;

            return returnValue;
        }
    }
}
