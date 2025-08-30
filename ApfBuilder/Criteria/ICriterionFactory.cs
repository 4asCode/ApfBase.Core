using ApfBuilder.Criteria;
using ApfBuilder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApfBuilder.Criteria.Core.Interfaces;

namespace ApfBuilder.Criteria
{
    public interface ICriterionFactory
    {
        ICriterion[] BaseStateCriteria { get; }

        ICriterion[] ForcedStateCriteria { get; }

        ICriterion[] AlternateCriteria { get; }
    }
}
