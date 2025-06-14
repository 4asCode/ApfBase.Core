using ApfBuilder.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApfBuilder.Criteria.CriterionAttribute;

namespace ApfBuilder.PowerFlow.Factory
{
    public class PowerFlowEmergencyFactory : IPowerFlowFactory
    {
        public IPowerFlow PowerFlow { get; }

        public PowerFlowEmergencyFactory(IEnumerable<ICriterion> criteria)
        {
            var filteredCriteria = Filter(criteria).ToList();

            PowerFlow = new PowerFlowEmergency(filteredCriteria);
        }

        private IEnumerable<ICriterion> Filter(
            IEnumerable<ICriterion> criteria)
        {
            var emergencyCriterion = criteria.Where(x => x
                .GetType()
                .GetCustomAttributes(typeof(EmergencyPF), false)
                .Any()
                )
            .FirstOrDefault();

            if (emergencyCriterion != null)
            {
                yield return emergencyCriterion;

                var secondCriteria = criteria.Where(x => x
                    .GetType()
                    .GetCustomAttributes(typeof(SecondaryAllowablePF), false)
                    .Any()
                );

                foreach (var secondCriterion in secondCriteria)
                {
                    if (secondCriterion?.MaxValue <
                        emergencyCriterion?.Value)
                    {
                        yield return secondCriterion;
                    }
                }
            }
        }
    }
}
