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
    public sealed class Frequency : CriterionBase, IFrequencyCriterion, IEmergencyResponseCriterion
    {
        public static ICriterion Create(PostFaultConditions postF)
             => new Frequency(postF);

        public override CriterionType Type => CriterionType.Frequency;

        public (string Value, string Description) FullValue { get; }

        public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

        public Conditions Condition { get; }

        public FrequencyPowerFlow FrequencyPowerFlow { get; }

        public Disturbances Disturbance { get; }

        public double? MinValueER { get; }

        public double? MaxValueER { get; }

        private Frequency(PostFaultConditions postF) : base()
        {
            try
            {
                Condition = postF.Conditions;
                FrequencyPowerFlow = postF.FrequencyPowerFlow;
                Disturbance = postF.Disturbances;
                EmergencyResponse = EmergencyResponseHandler.
                    ProcessHandler(base.RoundValue, this.Type, postF.APNU);

                Name = FrequencyPowerFlow?.PowerConsumptionName;
                Value = FrequencyPowerFlow?.PowerConsumptionFactor;
                MinValue = Value * FrequencyPowerFlow?.MinValue;
                MaxValue = Value * FrequencyPowerFlow?.MaxValue;

                MinValueER = MinValue;
                MaxValueER = MaxValue;
                foreach (var e in EmergencyResponse)
                {
                    MinValueER += e.MinValue;
                    MaxValueER += e.MaxValue;
                }

                FullValue =
                (
                    $"{FrequencyPowerFlow?.FrequencyFormalNameProxy}" +
                    (postF?.PreFaultConditions?.IrOscExpressions != null ?
                    " - ΔPнк" : ""),
                    $"{FrequencyPowerFlow?.PowerConsumptionFactor * 100}" +
                    $"% {Name}" +
                    (postF?.PreFaultConditions?.IrOscExpressions != null ?
                    " - ΔPнк" : "")
                );
            }
            catch (Exception ex)
            {
                throw new CriterionException(
                    $"Ошибка создания критерия '{Type}'", ex);
            }
        }
    }
}
