using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApfBuilder.Criteria
{
    public interface IFrequencyAlternateCriterion : IEmergencyResponceCriterion 
    {
        IEmergencyResponceCriterion StaticCriterion { get; }

        double? LimitPowerFlow { get; }

        double? LimitPowerFlowByEmergency { get; }

        int? IrOscExpressions { get; }
    }
}
