using System;

namespace Exceptions.Serialize
{
    public class SerializerException : Exception
    {
        public SerializerException(string message, Exception inner)
            : base(message, inner) { }
    }
}
