using ApfBuilder.Criteria.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static ApfBuilder.Criteria.CriterionAttribute;

namespace ApfBuilder.Criteria
{
    public static class CriterionExtension
    {
        public static ICriterion Min(
            this IEnumerable<ICriterion> criteria, 
            Func<ICriterion, double?> compare)
        {
            if (criteria.All(x => x.Value == null)) return null;

            List<ICriterion> listCriteria = criteria.ToList();

            var minValue = listCriteria.Min<ICriterion>(compare);

            var minValueCriteria = listCriteria
                .Where(c => compare(c) == minValue)
                .ToList();

            ICriterion minCriterion;

            if (minValueCriteria.Count > 1)
            {
                minCriterion = minValueCriteria.
                    OrderBy(GetPriority).First();
            }
            else
            {
                minCriterion = minValueCriteria.First();
            }

            return minCriterion;
        }

        public static void Sort(this ICriterion[] criteria)
        {
            ICriterion temp;
            for (int i = 0; i < criteria.Count(); i++)
            {
                for (int j = i + 1; j < criteria.Count(); j++)
                {
                    if (criteria[i].Value >
                        criteria[j].Value)
                    {
                        temp = criteria[i];
                        criteria[i] = criteria[j];
                        criteria[j] = temp;
                    }
                }
            }
        }

        private static int GetPriority(this ICriterion criterion)
        {
            var priorityAttr = criterion
                .GetType()
                .GetCustomAttributes(typeof(CriterionPriority), false)
                .FirstOrDefault() as CriterionPriority;

            return priorityAttr?.Priority ?? int.MaxValue;
        }
    }
}
