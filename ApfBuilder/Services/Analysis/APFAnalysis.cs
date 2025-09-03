using ApfBuilder.Context;
using ApfBuilder.Services.Analysis.AppliedCriteria;
using ApfBuilder.Services.Analysis.Reference;

namespace ApfBuilder.Services.Analysis
{
    public static class APFAnalysis
    {
        public static IAPFReference GetReference(
            this IAPFContext context) => new APFReference(context);

        public static IAPFApplied GetAppliedSecondaryCriterion(
            this IAPFContext context) => new APFAppliedCriteria(context);
    }
}
