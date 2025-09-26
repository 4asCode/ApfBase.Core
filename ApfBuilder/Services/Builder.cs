using ApfBuilder.Context;
using ApfBuilder.Criteria;
using ApfBuilder.Criteria.Core.Interfaces;
using ApfBuilder.PowerFlow;
using ApfBuilder.PowerFlow.Factory;
using System.Collections.Generic;
using System.Linq;

namespace ApfBuilder.Services
{
    public class Builder
    {
        private Builder() { }

        public static IPowerFlow[] Build(IAPFContext context)
        {
            var builder = new Builder();

            var powerFlows = builder.GetBaseStatePowerFlow(context)
                .Concat(builder.GetForcedStatePowerFlow(context)
                )
            .ToArray();
            
            return powerFlows;
        }

        private IEnumerable<IPowerFlow> GetBaseStatePowerFlow(
            IAPFContext context)
        {
            var baseCriteria = GetBaseStateCriteria(context);

            if (baseCriteria.All(c => c.Value == null)) yield break;

            var factories = PowerFlowCollectionFactory.Create(baseCriteria);

            foreach ( var factory in factories)
            {
                yield return factory.PowerFlow;
            }
        }

        private IEnumerable<IPowerFlow> GetForcedStatePowerFlow(
            IAPFContext context)
        {
            var criteria = GetForcedStateCriteria(context);

            if (criteria.All(c => c.Value == null)) yield break;

            var factory = new PowerFlowForcedStateFactory(criteria);

            yield return factory.PowerFlow;
        }

        private ICriterion[] GetBaseStateCriteria(IAPFContext context)
        {
            var factory = new CriterionFactory(context); 
            
            return factory.BaseStateCriteria;
        }

        private ICriterion[] GetForcedStateCriteria(IAPFContext context)
        {
            var factory = new CriterionFactory(context);

            return factory.ForcedStateCriteria;
        }
    }
}
