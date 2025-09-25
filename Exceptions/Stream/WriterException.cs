using System;

namespace Exceptions.Stream
{
    class WriterException : Exception
    {
        public WriterException(string message, Exception inner)
            : base(message, inner) { }
    }
}
