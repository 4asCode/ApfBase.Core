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
    public sealed class Frequency : CriterionBase, IFrequencyCriterion, IEmergencyResponseCriterion
    {
        public static ICriterion Create(PostFaultConditions postF)
             => new Frequency(postF);

        public override CriterionType Type => CriterionType.Frequency;

        public (string Value, string Description) FullValue { get; }

        public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

        public Conditions Condition { get; }

        public Disturbances Disturbance { get; }

        public double? MinValueER { get; }

        public double? MaxValueER { get; }

        private Frequency(PostFaultConditions postF) : base()
        {
            //MinValue = postF?.FrequencyPowerFlow?
            //    .MinValue;

            //MaxValue = postF?.FrequencyPowerFlow?
            //    .MaxValue;

            //Name = postF?.FrequencyPowerFlow?.PowerConsumptionDescription;

            //Value = postF?.FrequencyPowerFlow?.PowerConsumptionFactor;

            //FullValue = 
            //(
            //    $"{postF?.Disturbances?.PowerConsumptionFactor}" +
            //    $"*{Name} - ΔPнк", 
            //    $"{postF?.Disturbances?.PowerConsumptionFactor * 100}" +
            //    $"% {Name} - ΔPнк"
            //);

            //Condition = postF.Conditions;
            //Disturbance = postF.Disturbances;
            //EmergencyResponse = EmergencyResponseHandler.
            //    ProcessHandler(this.Type, postF.APNU);

            //MinValueER = MinValue;
            //MaxValueER = MaxValue;
            //foreach (var e in EmergencyResponse)
            //{
            //    MinValueER += e.MinValue;
            //    MaxValueER += e.MaxValue;
            //}
        }
    }
}
