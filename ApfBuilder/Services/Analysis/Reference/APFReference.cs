using ApfBuilder.Context;
using ApfBuilder.Criteria.Core.Interfaces;
using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApfBuilder.Services.Analysis.Reference
{
    [Serializable]
    public class APFReference : IAPFReference
    {
        public PowerFlowReference[] PowerFlowReference { get; set; }

        public APFReference() { }

        public APFReference(IAPFContext apfContext)
        {
            PowerFlowReference = GetReference(apfContext).ToArray();
        }

        private IEnumerable<PowerFlowReference> GetReference(
            IAPFContext context)
        {
            if (context == null || context.PowerFlows == null) yield break;

            foreach (var pf in context.PowerFlows)
            {
                var pfr = new PowerFlowReference(pf.Kind);

                foreach (var criterion in pf.Criteria 
                    ?? Enumerable.Empty<ICriterion>())
                {
                    if (criterion is ICurrentCriterion current && 
                        current.Bounding != null)
                    {
                        pfr.SummaryReference.Add(
                            nameof(BoundingElements), current.Bounding.Id);
                    }

                    if (criterion is IEmergencyResponseCriterion emr && 
                        emr.Disturbance != null)
                    {
                        pfr.SummaryReference.Add(
                            nameof(Disturbances), emr.Disturbance.Id);
                    }
                }

                var r = pfr.SummaryReference;
                var beCount = r.GetCount(nameof(BoundingElements));
                var dsCount = r.GetCount(nameof(Disturbances));

                if (beCount == 0 && dsCount == 0) continue;

                yield return pfr;
            }
        }
    }
}
