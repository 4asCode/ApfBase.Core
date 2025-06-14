using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApfBuilder.Criteria
{
    public enum CriterionType
    {
        Current,
        Dynamic,
        Static,
        Voltage,
        Frequency,
        FrequencyAlternate,
        CurrentAOPO,
        CurrentSecondary,
        VoltageSecondary,
        StaticBaseCaseTPR,
        StaticBaseCaseEPR
    }
}
