using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseModels.ApfBaseEntities;

namespace ApfBuilder.Criteria.Core.Interfaces
{
    public interface ICurrentCriterion : ICriterion 
    {
        BoundingElements Bounding { get; }
    }
}
