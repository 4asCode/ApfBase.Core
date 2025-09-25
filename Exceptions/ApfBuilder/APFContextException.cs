using System;

namespace Exceptions.ApfBuilder
{
    public class APFContextException : Exception
    {
        public APFContextException(string message, Exception inner)
            : base(message, inner) { }
    }
}
