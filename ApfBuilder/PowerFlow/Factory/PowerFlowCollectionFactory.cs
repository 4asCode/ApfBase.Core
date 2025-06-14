using ApfBuilder.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
