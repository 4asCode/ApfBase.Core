using ApfBuilder.Criteria;
using ApfBuilder.Criteria.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ApfBuilder.PowerFlow
{
    public abstract class PowerFlowBase : Composer, IPowerFlow
    {
        public abstract PowerFlowKind Kind { get; }

        public ICriterion[] Criteria { get; protected set; }

        public string Value { get; protected set; } = string.Empty;

        public string Description { get; protected set; } = string.Empty;

        protected PowerFlowBase(IEnumerable<ICriterion> criteria)
        {
            Criteria = criteria.ToArray();
            Criteria.Sort(x => x.ComplexMinValue);
        }
    }
}
