using ApfBuilder.Services;
using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApfBuilder.Criteria.Core.Interfaces;
using static ApfBuilder.Criteria.CriterionAttribute;
using Exceptions;

namespace ApfBuilder.Criteria.Core
{
    [AllowablePF]
    [CriterionPriority(1)]
    public sealed class Current : CriterionBase, ICurrentCriterion, IEmergencyResponseCriterion
    {
        public static ICriterion CreateStandard(
            PostFaultConditions postF)
        {
            return new Current
                (
                    postF,
                    postF.CurrentPowerFlow -
                        postF.PreFaultConditions.IrOscExpressions ??
                        postF.CurrentPowerFlow,
                    "АДТН"
                );
        }

        public static ICriterion CreateAOPO(
            PostFaultConditions postF)
        {
            return new Current
                (
                    postF,
                    postF.CurrentAOPO -
                        postF.PreFaultConditions.IrOscExpressions ??
                        postF.CurrentAOPO,
                    "ДТН"
                );
        }

        public override CriterionType Type => CriterionType.Current;

        public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

        public Conditions Condition { get; }

        public Disturbances Disturbance { get; }

        public BoundingElements Bounding { get; }

        public double? MinValueER { get; }

        public double? MaxValueER { get; }

        private Current(PostFaultConditions postF,
            double? value, string name)
            : base
            (
                  postF.PreFaultConditions
                      ?.BranchGroupVsBranchGroupScheme
                      ?.BranchGroup
                      ?.RoundValue,
                  value,
                  postF.Conditions
            )
        {
            try
            {
                Name = name;
                Condition = postF.Conditions;
                Disturbance = postF.Disturbances;
                Bounding = postF.BoundingElements;
                EmergencyResponse = EmergencyResponseHandler.
                    ProcessHandler(base.RoundValue, this.Type, postF.AOPO);

                MinValueER = MinValue;
                MaxValueER = MaxValue;
                foreach (var e in EmergencyResponse)
                {
                    MinValueER += e.MinValue;
                    MaxValueER += e.MaxValue;
                }
            }
            catch (Exception ex)
            {
                throw new CriterionException(
                    $"Ошибка создания критерия '{Type}'", ex);
            }
        }
    }
}
