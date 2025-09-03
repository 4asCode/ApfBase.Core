using ApfBuilder.Context;
using ApfBuilder.Criteria.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApfBuilder.Services.Analysis.AppliedCriteria
{
    [Serializable]
    public class APFAppliedCriteria : IAPFApplied
    {
        public CriterionInfo[] AppliedCriteria { get; set; }

        public APFAppliedCriteria() { }

        public APFAppliedCriteria(IAPFContext apfContext)
        {
            AppliedCriteria = GetSecondaryCriteria(
                apfContext).ToArray();
        }

        private IEnumerable<CriterionInfo> GetSecondaryCriteria(
            IAPFContext context)
        {
            if (context == null || context.PowerFlows == null) yield break;

            foreach (var pf in context.PowerFlows)
            {
                foreach (var criterion in pf.Criteria
                    ?? Enumerable.Empty<ICriterion>())
                {
                    if (criterion is ISecondaryCriterion secondary)
                    {
                        yield return new CriterionInfo(
                            pf.Kind, secondary.Type, 
                            (double)secondary.Value);
                    }
                }
            }
        }
    }
}
