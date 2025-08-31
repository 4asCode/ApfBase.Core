using ApfBuilder.Context;
using ApfBuilder.PowerFlow;
using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApfBuilder.Services.Analysis
{
    [Serializable]
    public class PowerFlowReference
    {
        public PowerFlowKind Kind { get; }

        public SummaryReference SummaryReference { get; set; } = 
            new SummaryReference();

        public PowerFlowReference() { }

        public PowerFlowReference(PowerFlowKind kind)
        {
            Kind = kind;
        }
    }
}
