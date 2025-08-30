using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApfBuilder.Criteria.Core.Interfaces;
using System.Threading.Tasks;

namespace ApfBuilder.Criteria.Core
{
    public sealed class FrequencyAlternate : CriterionBase, IFrequencyAlternateCriterion
    {
        public static ICriterion Create(PostFaultConditions postF)
             => new FrequencyAlternate(postF);

        public override CriterionType Type => CriterionType.FrequencyAlternate;

        public IEmergencyResponseCriterion StaticCriterion { get; }

        public double? LimitPowerFlow { get; }

        public double? LimitPowerFlowByEmergency { get; }

        public int? IrOscExpressions { get; }

        public IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

        public Conditions Condition { get; }

        public Disturbances Disturbance { get; }

        public double? MinValueER { get; }

        public double? MaxValueER { get; }

        private FrequencyAlternate(PostFaultConditions postF) : base()
        {
            //StaticCriterion = Static.Create(postF) 
            //    as IEmergencyResponceCriterion;
            //LimitPowerFlow = postF?.PreFaultConditions?.LimitPowerFlow;
            //IrOscExpressions = postF.PreFaultConditions?.IrOscExpressions;
            //LimitPowerFlowByEmergency = StaticCriterion?.Value != null && 
            //    IrOscExpressions != null 
            //    ? StaticCriterion.Value + IrOscExpressions 
            //    : null;

            //Value = double.MaxValue;
            //Name = postF.Disturbances?.PowerConsumptionDescription;

            //Condition = postF.Conditions;
            //Disturbance = postF.Disturbances;
            //EmergencyResponse = EmergencyResponseHandler.
            //    ProcessHandler(this.Type, postF.APNU);
        }
    }
}
