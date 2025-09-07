using ApfBuilder.Context;
using ApfBuilder.Criteria;
using ApfBuilder.PowerFlow.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApfBuilder.Criteria.Core.Interfaces;
using System.Threading.Tasks;

namespace ApfBuilder.PowerFlow
{
    public class PowerFlowStandard : PowerFlowBase
    {
        public override PowerFlowKind Kind => PowerFlowKind.PowerFlowStandard;

        public PowerFlowStandard(IEnumerable<ICriterion> criteria)
            : base(criteria)
        {
            Compose();
        }

        public override void Compose()
        {
            foreach (var criterion in Criteria)
            {
                if (criterion is IFrequencyAlternateCriterion) continue;

                switch (criterion)
                {
                    case IBaseCaseCriterion baseCaseCriterion:
                        Value += $"{baseCaseCriterion.Value} " +
                            $"{baseCaseCriterion.Condition?.FormalName}";
                        Description += baseCaseCriterion.Name;

                        Value = TerminateLine(Value);
                        Description = TerminateLine(Description);
                        continue;
                    case IFrequencyCriterion frequencyCriterion:
                        Value += frequencyCriterion.FullValue.Value;
                        Description +=
                            $"{frequencyCriterion.FullValue.Description}" +
                            (frequencyCriterion.Disturbance?.Number != null ?
                            $", ПАР {frequencyCriterion.Disturbance.Number}" 
                            : "");

                        Value = TerminateLine(Value);
                        Description = TerminateLine(Description);

                        continue;
                }

                Value += criterion.Value;

                if (criterion is ISecondaryCriterion secondaryCriterion)
                {
                    Value += $"{secondaryCriterion.Postfix} " +
                        $"{secondaryCriterion.Condition?.FormalName}";
                    Description +=
                        $"{secondaryCriterion.Name}" +
                        (secondaryCriterion is ICurrentCriterion currentSec ?
                        $" {currentSec.Bounding?.Number}" : "");

                    Value = TerminateLine(Value);
                    Description = TerminateLine(Description);
                }

                if (criterion is IEmergencyResponseCriterion complexCriterion)
                {
                    Value += $" {complexCriterion.Condition?.FormalName}";

                    Description += 
                        $"{complexCriterion.Name}" +
                        (complexCriterion is ICurrentCriterion currentEmerg ?
                        $" {currentEmerg.Bounding?.Number}" : "") +
                        (complexCriterion.Disturbance?.Number != null ? 
                        $", ПАР {complexCriterion.Disturbance.Number}" : "");

                    Value = TerminateLine(Value);
                    Description = TerminateLine(Description);
                }
            }

            var prefixsCriteria = Criteria.Where(
                x => !(x is IFrequencyAlternateCriterion)
                );
            var isNeedPrefix = prefixsCriteria.Skip(1).Any();

            Value = GetValuePrefix(
                Value.TrimEnd(' ', ';', '\n'), isNeedPrefix
            );

            Description = GetDescriptionPrefix(
                Description.TrimEnd(' ', ';', '\n'), isNeedPrefix
            );

            var alternateCriteria = Criteria
                .OfType<IFrequencyAlternateCriterion>();

            //Value += "\n";
            //Description += "\n";
            //foreach (var alternateCriterion in alternateCriteria)
            //{
            //    Value +=
            //        $"МАКС\n" +
            //        $"({alternateCriterion.StaticCriterion.Value}" +
            //        (alternateCriterion.Condition?.ReplacementOf?.FormalName != null
            //        ? $"{alternateCriterion.Condition.ReplacementOf.FormalName}"
            //        : "") + ";\n" +
            //        $"{alternateCriterion.Disturbance?.PowerConsumptionFactor}" +
            //        $"*({alternateCriterion.Name})" +
            //        $"- ΔPнк)";
            //    Description +=
            //        $"\n" +
            //        $"{alternateCriterion.StaticCriterion?.Name}" +
            //        (alternateCriterion.Disturbance?.Number != null 
            //        ? $", ПАР {alternateCriterion.Disturbance.Number}" : "") + ";\n" +
            //        $"{alternateCriterion.Disturbance?.PowerConsumptionFactor * 100}" +
            //        $"% Pпотр ПАР {alternateCriterion.Disturbance?.Number}";

            //    Value = TerminateLine(Value);
            //    Description = TerminateLine(Description);
            //}
        }
    }
}
