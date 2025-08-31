using ApfBuilder.Context;
using ApfBuilder.Criteria;
using ApfBuilder.PowerFlow;
using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApfBuilder.Criteria.Core;
using System.Threading.Tasks;

namespace ApfBuilder.Services.Analysis
{
    public static class APFAnalysis
    {
        public static IAPFReference GetReference(
            this IAPFContext context) => new APFReference(context);
    }
}
