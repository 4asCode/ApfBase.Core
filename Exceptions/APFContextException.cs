using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class APFContextException : Exception
    {
        public APFContextException(string participant, Exception inner)
            : base($"Ошибка при формировании формул ДП! '{participant}'", 
                  inner) { }
    }
}
