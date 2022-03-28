using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.CustomExceptions
{
    [Serializable]
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException()
        { }

        public ObjectNotFoundException(string? message) : base(message)
        { }

        public ObjectNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        { }
    }
}
