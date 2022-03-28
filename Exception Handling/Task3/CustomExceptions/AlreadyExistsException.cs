using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.CustomExceptions
{
    [Serializable]
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException()
        { }

        public AlreadyExistsException(string? message) : base(message)
        { }

        public AlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        { }
    }
}
