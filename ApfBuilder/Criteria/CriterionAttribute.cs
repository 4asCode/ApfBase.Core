using System;

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
