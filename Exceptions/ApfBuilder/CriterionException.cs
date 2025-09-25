using System;

namespace Exceptions.ApfBuilder
{
    public class CriterionException : Exception
    {
        public CriterionException(string message, Exception inner)
            : base(message, inner) { }
    }
}
