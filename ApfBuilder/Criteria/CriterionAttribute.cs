using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApfBuilder.Criteria
{
    public class CriterionAttribute
    {
        public class AllowablePF : Attribute { }

        public class SecondaryAllowablePF : Attribute { }

        public class EmergencyPF : Attribute { }

        public class CriterionPriority : Attribute
        {
            public int Priority { get; }

            public CriterionPriority(int priority)
            {
                Priority = priority;
            }
        }
    }
}
