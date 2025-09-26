using ApfBuilder.Criteria.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ApfBuilder.PowerFlow.Factory
{
    public class PowerFlowCollectionFactory : IPowerFlowCollectionFactory
    {
        public IEnumerable<IPowerFlowFactory> PowerFlowFactories { get; }

        private PowerFlowCollectionFactory(
            IEnumerable<ICriterion> criteria)
        {
            PowerFlowFactories = new IPowerFlowFactory[]
            {
                new PowerFlowStandardFactory(criteria),
                new PowerFlowSafeFactory(criteria),
                new PowerFlowEmergencyFactory(criteria)
            };
        }

        public static IPowerFlowFactory[] Create(
            IEnumerable<ICriterion> criteria) => 
            new PowerFlowCollectionFactory(criteria)
                .PowerFlowFactories
                .ToArray();
    }
}
