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
    [CriterionPriority(2)]
    public sealed class Dynamic : CriterionBase, IEmergencyResponseCriterion
    {
        public static ICriterion Create(PostFaultConditions postF)
            => new Dynamic(postF);

        public override CriterionType Type => CriterionType.Dynamic;

        public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

        public Conditions Condition { get; }

        public Disturbances Disturbance { get; }

        public double? MinValueER { get; }

        public double? MaxValueER { get; }

        private Dynamic(PostFaultConditions postF)
            : base
            (
                  postF.PreFaultConditions
                      ?.BranchGroupVsBranchGroupScheme
                      ?.BranchGroup
                      ?.RoundValue,
                  postF.DynamicPowerFlow -
                    postF.PreFaultConditions.IrOscExpressions ??
                    postF.DynamicPowerFlow,
                  postF.Conditions
            )
        {
            try
            {
                Name = "ДУ";
                Condition = postF.Conditions;
                Disturbance = postF.Disturbances;
                EmergencyResponse = EmergencyResponseHandler.
                    ProcessHandler(base.RoundValue, this.Type, postF.APNU);

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
