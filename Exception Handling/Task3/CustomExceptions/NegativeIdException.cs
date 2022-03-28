using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.CustomExceptions
{
    [Serializable]
    public class NegativeIdException : Exception
    {
        public NegativeIdException()
        { }

        public NegativeIdException(string? message) : base(message)
        { }

        public NegativeIdException(string? message, Exception? innerException) : base(message, innerException)
        { }
    }
}
