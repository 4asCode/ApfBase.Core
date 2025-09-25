using System;

namespace Exceptions.ApfBuilder
{
    public class APFContextException : Exception
    {
        public APFContextException(string participant, Exception inner)
            : base($"Ошибка при формировании формул ДП! '{participant}'", 
                  inner) { }
    }
}
