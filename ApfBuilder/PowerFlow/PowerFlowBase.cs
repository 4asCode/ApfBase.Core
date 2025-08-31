using ApfBuilder.Criteria;
using ApfBuilder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApfBuilder.Criteria.Core.Interfaces;
using System.Threading.Tasks;

namespace ApfBuilder.PowerFlow
{
    public abstract class PowerFlowBase : Composer, IPowerFlow
    {
        public abstract PowerFlowKind Kind { get; }

        public ICriterion[] Criteria { get; }

        public string Value { get; protected set; } = string.Empty;

        public string Description { get; protected set; } = string.Empty;

        protected PowerFlowBase(IEnumerable<ICriterion> criteria)
        {
            Criteria = criteria.ToArray();
            Criteria.Sort();
        }
    }
}
