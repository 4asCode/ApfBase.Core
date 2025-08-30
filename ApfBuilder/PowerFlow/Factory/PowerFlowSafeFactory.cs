using ApfBuilder.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApfBuilder.Criteria.Core.Interfaces;
using static ApfBuilder.Criteria.CriterionAttribute;

namespace ApfBuilder.PowerFlow.Factory
{
    public  class PowerFlowSafeFactory : IPowerFlowFactory
    {
        public IPowerFlow PowerFlow { get; }

        public PowerFlowSafeFactory(IEnumerable<ICriterion> criteria)
        {
            var filteredCriteria = Filter(criteria).ToList();

            PowerFlow = new PowerFlowSafe(filteredCriteria);
        }

        private IEnumerable<ICriterion> Filter(
            IEnumerable<ICriterion> criteria)
        {
            var baseCriteria = criteria.Where(x => x
                .GetType()
                .GetCustomAttributes(typeof(AllowablePF), false)
                .Any()
                );

            var emergencyResponceCriteria = baseCriteria
                .OfType<IEmergencyResponseCriterion>();

            var otherCriteria = baseCriteria.Except(
                emergencyResponceCriteria);

            var minValueOfMaxValueBaseEmergency = emergencyResponceCriteria
                .Min(
                        (ICriterion c) => 
                        (c as IEmergencyResponseCriterion).MaxValueER
                    )
                as IEmergencyResponseCriterion;

            var minValueOfMaxValueBaseOther = otherCriteria.Min(
                x => x.MaxValue);

            var otherMax = minValueOfMaxValueBaseOther?.MaxValue;
            var emergencyMax = minValueOfMaxValueBaseEmergency?.MaxValueER;

            double? minValueOfMaxValueBaseResult;

            if (otherMax == null)
            {
                minValueOfMaxValueBaseResult = emergencyMax;
            }
            else if (emergencyMax == null)
            {
                minValueOfMaxValueBaseResult = otherMax;
            }
            else
            {
                minValueOfMaxValueBaseResult = emergencyMax < otherMax 
                    ? emergencyMax 
                    : otherMax;
            }

            var secondCriteria = criteria.Where(x => x
                .GetType()
                .GetCustomAttributes(typeof(SecondaryAllowablePF), false)
                .Any()
            );

            foreach (var secondCriterion in secondCriteria)
            {
                if (secondCriterion?.MaxValue <
                    minValueOfMaxValueBaseResult)
                {
                    yield return secondCriterion;
                }
            }

            foreach (var criterion in emergencyResponceCriteria?.ToList())
            {
                if (criterion?.MinValueER <= minValueOfMaxValueBaseResult)
                {
                    yield return criterion;
                }
            }

            foreach (var criterion in otherCriteria?.ToList())
            {
                if (criterion?.MinValue <= minValueOfMaxValueBaseResult)
                {
                    yield return criterion;
                }
            }

            foreach (var criterion in criteria)
            {
                if (criterion.Type == CriterionType.FrequencyAlternate)
                {
                    yield return criterion;
                }
            }
        }
    }
}
