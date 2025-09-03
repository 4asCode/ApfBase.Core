using ApfBuilder.PowerFlow;
using System;

namespace ApfBuilder.Services.Analysis.Reference
{
    [Serializable]
    public class PowerFlowReference
    {
        public PowerFlowKind Kind { get; set; }

        public SummaryReference SummaryReference { get; set; } = 
            new SummaryReference();

        public PowerFlowReference() { }

        public PowerFlowReference(PowerFlowKind kind)
        {
            Kind = kind;
        }
    }
}
