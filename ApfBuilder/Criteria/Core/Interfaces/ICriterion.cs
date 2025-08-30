using DataBaseModels.ApfBaseEntities;
using ApfBuilder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApfBuilder.Criteria.Core.Interfaces
{
    public interface ICriterion
    {
        string Name { get; }

        double? Value{ get; }

        double? MinValue { get; }

        double? MaxValue { get; }

        CriterionType Type { get; }
    }
}
