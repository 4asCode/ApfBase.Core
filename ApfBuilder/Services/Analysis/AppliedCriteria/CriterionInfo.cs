using ApfBuilder.Criteria.Core;
using ApfBuilder.PowerFlow;

namespace ApfBuilder.Services.Analysis.AppliedCriteria
{
    public class CriterionInfo
    {
        public PowerFlowKind Kind { get; set; }

        public CriterionType CriterionType { get; set; }

        public double Value { get; set; }

        public CriterionInfo(PowerFlowKind kind, 
            CriterionType type, double value)
        {
            Kind = kind;
            CriterionType = type;
            Value = value;
        }
    }
}
