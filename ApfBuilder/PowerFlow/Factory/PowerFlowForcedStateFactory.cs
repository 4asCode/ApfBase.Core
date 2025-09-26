using ApfBuilder.Criteria.Core.Interfaces;
using System.Collections.Generic;

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
