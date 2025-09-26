using ApfBuilder.Criteria;
using ApfBuilder.Criteria.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ApfBuilder.Services
{
    public class CriterionSelector
    {
        public IEnumerable<ICriterion> GetSimpleSelector(
            IEnumerable<ICriterion> criteriaList) 
                => criteriaList.Where(c => c.Value != null);

        public IEnumerable<ICriterion> GetComplexSelector(
            IEnumerable<ICriterion[]> 
            criteriaList)
        {
            foreach (var criteria in criteriaList)
            {
                var correctCriteria = criteria.Where(
                    c => c.Value != null).ToList();

                if (!correctCriteria.Any()) continue;

                var minCriterion = correctCriteria.Min(c => c.Value);

                yield return minCriterion;
            }
        }
    }
}
