using ApfBuilder.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApfBuilder.Criteria.Core.Interfaces;
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

            if (emergencyCriterion != null)
            {
                Value += emergencyCriterion.Value;
                Description += emergencyCriterion.Name;
            }
        }
    }
}
