using ApfBuilder.Services;
using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApfBuilder.Criteria.Core.Interfaces;
using static ApfBuilder.Criteria.CriterionAttribute;

namespace ApfBuilder.Criteria.Core
{
    [AllowablePF]
    [CriterionPriority(1)]
    public sealed class CurrentAOPO : CriterionBase, ICurrentCriterion, IEmergencyResponseCriterion
    {
        public static ICriterion Create(PostFaultConditions postF)
             => new CurrentAOPO(postF);

        public override CriterionType Type => CriterionType.CurrentAOPO;

        public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

        public Conditions Condition { get; }

        public Disturbances Disturbance { get; }

        public BoundingElements Bounding { get; }

        public double? MinValueER { get; }

        public double? MaxValueER { get; }

        private CurrentAOPO(PostFaultConditions postF)
            : base
            (
                postF.CurrentAOPO -
                    postF.PreFaultConditions.IrOscExpressions ??
                    postF.CurrentAOPO,
                postF.Conditions
            )
        {
            Name = "ДТН";
            Condition = postF.Conditions;
            Disturbance = postF.Disturbances;
            Bounding = postF.BoundingElements;
            EmergencyResponse = EmergencyResponseHandler.
                ProcessHandler(this.Type, postF.AOPO);

            MinValueER = MinValue;
            MaxValueER = MaxValue;
            foreach (var e in EmergencyResponse)
            {
                MinValueER += e.MinValue;
                MaxValueER += e.MaxValue;
            }
        }
    }
}
