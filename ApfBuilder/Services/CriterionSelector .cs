using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApfBuilder.Criteria;
using ApfBuilder.Context;
using static Z.EntityFramework.Extensions.BatchUpdate;

namespace ApfBuilder.Services
{
    public class CriterionSelector
    {
        public IEnumerable<ICriterion> GetSimpleSelector(
            IEnumerable<ICriterion> criteriaList) 
                => criteriaList.Where(c => c.Value != null && c.Value > 0);

        public IEnumerable<ICriterion> GetComplexSelector(
            IEnumerable<ICriterion[]> 
            criteriaList)
        {
            foreach (var criteria in criteriaList)
            {
                var correctCriteria = criteria.Where(
                    c => c.Value != null && c.Value > 0).ToList();

                if (!correctCriteria.Any()) continue;

                var minCriterion = correctCriteria.Min(c => c.Value);

                yield return minCriterion;
            }
        }

        public IEnumerable<ICriterion> GetAlternateSelector(
            IEnumerable<ICriterion> criteria)
        {
            foreach (var criterion in criteria)
            {
                var alternate = criterion as IFrequencyAlternateCriterion;

                if (alternate?.StaticCriterion != null &&
                    alternate.StaticCriterion.Value.HasValue && 
                    alternate.LimitPowerFlowByEmergency > 0 &&
                    alternate?.IrOscExpressions != null &&
                    (alternate.LimitPowerFlowByEmergency / 0.92) <
                    alternate?.IrOscExpressions * 3)
                {
                    yield return criterion;
                }
                //else if (alternate.StaticCriterion.Value.HasValue &&
                //        alternate.LimitPowerFlowByEmergency > 0 &&
                //        alternate?.IrOscExpressions != null &&
                //        (alternate.LimitPowerFlowByEmergency / 0.92) <
                //        alternate?.LimitPowerFlow * 0.3)
                //{
                //    yield return criterion;
                //}
                //else if (alternate.StaticCriterion.Value.HasValue &&
                //        alternate.Condition?.MaxValue != null &&
                //        alternate.Condition.MaxValue >
                //        alternate?.LimitPowerFlow * 0.5)
                //{
                //    yield return criterion;
                //}
            }
        }
    }
}
