using ApfBuilder.Criteria;
using ApfBuilder.Criteria.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApfBuilder.Criteria.Core.Interfaces;
using static ApfBuilder.Criteria.CriterionAttribute;

namespace ApfBuilder.PowerFlow.Factory
{
    public class PowerFlowStandardFactory : IPowerFlowFactory
    {
        public IPowerFlow PowerFlow { get; }

        public PowerFlowStandardFactory(IEnumerable<ICriterion> criteria)
        {
            var filteredCriteria = Filter(criteria).ToList();

            PowerFlow = new PowerFlowStandard(filteredCriteria);
        }

        private IEnumerable<ICriterion> Filter(
            IEnumerable<ICriterion> criteria)
        {
            var baseCriteria = criteria.Where(x => x
                .GetType()
                .GetCustomAttributes(typeof(AllowablePF), false)
                .Any()
            );

            var minValueOfMaxValueBase = baseCriteria.Min(
                c => c.MaxValue);

            var secondCriteria = criteria.Where(x => x
                .GetType()
                .GetCustomAttributes(typeof(SecondaryAllowablePF), false)
                .Any()
            );

            foreach (var secondCriterion in secondCriteria)
            {
                if (secondCriterion?.MaxValue <
                    minValueOfMaxValueBase?.MaxValue)
                {
                    yield return secondCriterion;
                }
            }

            foreach (var criterion in baseCriteria?.ToList())
            {
                if (criterion?.MinValue <= minValueOfMaxValueBase?.MaxValue)
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
