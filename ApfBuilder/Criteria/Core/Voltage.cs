using ApfBuilder.Criteria.Core.Interfaces;
using ApfBuilder.Services;
using DataBaseModels.ApfBaseEntities;
using Exceptions.ApfBuilder;
using System;
using System.Collections.Generic;
using static ApfBuilder.Criteria.CriterionAttribute;

namespace ApfBuilder.Criteria.Core
{
    [AllowablePF]
    [CriterionPriority(4)]
    public sealed class Voltage : CriterionBase, IEmergencyResponseCriterion
    {
        public static ICriterion Create(PostFaultConditions postF)
            => new Voltage(postF);

        public override CriterionType Type => CriterionType.Voltage;

        public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

        public Conditions Condition { get; }

        public Disturbances Disturbance { get; }

        public double? MinValueER { get; }

        public double? MaxValueER { get; }

        private Voltage(PostFaultConditions postF)
            : base
            (
                  postF.PreFaultConditions
                      ?.BranchGroupVsBranchGroupScheme
                      ?.BranchGroup
                      ?.RoundValue,
                  postF.VoltagePowerFlow -
                    postF.PreFaultConditions.IrOscExpressions ??
                    postF.VoltagePowerFlow,
                  postF.Conditions
            )
        {
            try
            {
                Name = "10% U";
                Condition = postF.Conditions;
                Disturbance = postF.Disturbances;
                EmergencyResponse = EmergencyResponseHandler.
                    ProcessHandler(base.RoundValue, this.Type, postF.AOSN);

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
