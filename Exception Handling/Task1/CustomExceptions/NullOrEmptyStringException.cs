using System;
using System.Runtime.Serialization;

namespace Task1.CustomExceptions
{
    [Serializable]
    public class NullOrEmptyStringException : Exception
    {
        public NullOrEmptyStringException()
        { }

        public NullOrEmptyStringException(string? message) : base(message)
        { }

        public NullOrEmptyStringException(string? message, Exception? innerException) : base(message, innerException)
        { }

        protected NullOrEmptyStringException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
