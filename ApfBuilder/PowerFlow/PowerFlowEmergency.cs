using ApfBuilder.Criteria.Core;
using ApfBuilder.Criteria.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using static ApfBuilder.Criteria.CriterionAttribute;

namespace ApfBuilder.PowerFlow
{
    public class PowerFlowEmergency : PowerFlowBase
    {
        public override PowerFlowKind Kind => 
            PowerFlowKind.PowerFlowEmergency;

        public PowerFlowEmergency(IEnumerable<ICriterion> criteria)
            : base(criteria)
        {
            Compose();
        }

        public override void Compose()
        {
            Criteria = Criteria.Where(x => x
                .GetType()
                .GetCustomAttributes(typeof(EmergencyPF), false)
                .Any()
                )
            .ToArray();

            var emergencyCriterion = Criteria.FirstOrDefault();

            if (emergencyCriterion != null && 
                emergencyCriterion is StaticBaseCaseEPR baseCaseEPR)
            {
                Value += $"{baseCaseEPR.Value} " +
                    $"{baseCaseEPR.Condition?.FormalName}".TrimEnd(' ');
                Description += baseCaseEPR.Name;
            }
        }
    }
}
