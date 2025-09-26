using System;

namespace Exceptions.MemoryTools
{
    public class MemoryException : Exception
    {
        public MemoryException(string message, Exception inner)
            : base(message, inner) { }
    }
}
