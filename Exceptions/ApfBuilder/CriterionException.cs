using System;

namespace Exceptions.ApfBuilder
{
    public class CriterionException : Exception
    {
        public CriterionException(string type, Exception inner)
            : base($"Ошибка создания критерия '{type}'", inner) { }
    }
}
