using ApfBuilder.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApfBuilder.Criteria.CriterionAttribute;

namespace ApfBuilder.PowerFlow
{
    public class PowerFlowEmergency : PowerFlowBase
    {
        public PowerFlowEmergency(IEnumerable<ICriterion> criteria)
            : base(criteria)
        {
            Compose();
        }

        public override void Compose()
        {
            var emergencyCriterion = Criteria.Where(x => x
                .GetType()
                .GetCustomAttributes(typeof(EmergencyPF), false)
                .Any()
                )
            .FirstOrDefault();

            if (emergencyCriterion != null)
            {
                Value += emergencyCriterion.Value;
                Description += emergencyCriterion.Name;
            }
        }
    }
}
