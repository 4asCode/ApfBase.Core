using System;

namespace Exceptions.DataBaseModels
{
    public class EntityQueryException : Exception
    {
        public EntityQueryException(string message, Exception inner)
            : base(message, inner) { }
    }
}
