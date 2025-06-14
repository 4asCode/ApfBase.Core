using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseModels.ApfBaseEntities;

namespace ApfBuilder.Criteria
{
    public interface IFrequencyCriterion : ICriterion
    {
        (string Value, string Description) FullValue { get; }

        Disturbances Disturbance { get; }
    }
}
