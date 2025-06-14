using ApfBuilder.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApfBuilder.Criteria.CriterionAttribute;

namespace ApfBuilder.PowerFlow.Factory
{
    public class PowerFlowForcedStateFactory : IPowerFlowFactory
    {
        public IPowerFlow PowerFlow { get; }

        public PowerFlowForcedStateFactory(IEnumerable<ICriterion> criteria)
        {
            PowerFlow = new PowerFlowForcedState(criteria);
        }
    }
}
