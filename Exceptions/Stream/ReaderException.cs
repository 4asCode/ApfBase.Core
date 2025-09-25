using System;

namespace Exceptions.Stream
{
    public class ReaderException : Exception
    {
        public ReaderException(string message, Exception inner)
            : base(message, inner) { }
    }
}
