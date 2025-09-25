using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class CriterionException : Exception
    {
        public CriterionException(string type, Exception inner)
            : base($"Ошибка создания критерия '{type}'", inner) { }
    }
}
