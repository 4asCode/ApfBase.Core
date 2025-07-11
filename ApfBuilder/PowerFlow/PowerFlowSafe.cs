﻿using ApfBuilder.Criteria;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApfBuilder.PowerFlow
{
    public class PowerFlowSafe : PowerFlowBase
    {
        public PowerFlowSafe(IEnumerable<ICriterion> criteria)
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
                        Value += baseCaseCriterion.Value;
                        Description += baseCaseCriterion.Name;

                        Value = $"{Value.TrimEnd(' ')};\n";
                        Description = $"{Description.TrimEnd(' ')};\n";
                        continue;
                    case IFrequencyCriterion frequencyCriterion:
                        Value += frequencyCriterion.FullValue.Value;
                        Description +=
                            $"{frequencyCriterion.FullValue.Description}" +
                            (frequencyCriterion.Disturbance?.Number != null ?
                            $", ПАР {frequencyCriterion.Disturbance.Number}"
                            : "");

                        var emergencyCriterion = frequencyCriterion as 
                            IEmergencyResponceCriterion;

                        (Value, Description) = EmergencyResponseCompose(
                            Value, Description, emergencyCriterion
                            );

                        Value = TerminateLine(Value);
                        Description = TerminateLine(Description);
                        continue;
                }

                Value += criterion.Value;

                if (criterion is ISecondaryCriterion secondaryCriterion)
                {
                    Value += secondaryCriterion.Postfix;
                    Description +=
                        $"{secondaryCriterion.Name}" +
                        (secondaryCriterion is ICurrentCriterion currentSec ?
                        $" {currentSec.Bounding?.Number}" : "");

                    Value = TerminateLine(Value);
                    Description = TerminateLine(Description);
                }

                if (criterion is IEmergencyResponceCriterion complexCriterion)
                {
                    Value += 
                        (complexCriterion.Condition?.FormalName != null ? 
                        $" {complexCriterion.Condition?.FormalName}" : "");

                    Description +=
                        $"{complexCriterion.Name}" +
                        (complexCriterion is ICurrentCriterion currentEmerg ?
                        $" {currentEmerg.Bounding?.Number}" : "") +
                        (complexCriterion.Disturbance?.Number != null ?
                        $", ПАР {complexCriterion.Disturbance.Number}" : "");

                    (Value, Description) = EmergencyResponseCompose(
                        Value, Description, complexCriterion
                        );

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

            Value += "\n";
            Description += "\n";
            foreach (var alternateCriterion in alternateCriteria)
            {
                var emergencyValue = string.Empty;
                var emergencyDescription = string.Empty;
                (emergencyValue, emergencyDescription) 
                    = EmergencyResponseCompose(
                        emergencyValue, emergencyDescription, 
                        alternateCriterion as IEmergencyResponceCriterion
                );

                Value +=
                    $"МАКС\n" +
                    $"({alternateCriterion.StaticCriterion.Value}" +
                    (alternateCriterion.Condition?.ReplacementOf?.FormalName != null
                    ? $"{alternateCriterion.Condition.ReplacementOf.FormalName}"
                    : "") + emergencyValue +";\n" +
                    $"{alternateCriterion.Disturbance?.PowerConsumptionFactor}" +
                    $"*({alternateCriterion.Name})" +
                    $"- ΔPнк)";
                Description +=
                    $"\n" +
                    $"{alternateCriterion.StaticCriterion?.Name}" +
                    (alternateCriterion.Disturbance?.Number != null
                    ? $", ПАР {alternateCriterion.Disturbance.Number}" : "") +
                    emergencyDescription + ";\n" +
                    $"{alternateCriterion.Disturbance?.PowerConsumptionFactor * 100}" +
                    $"% Pпотр ПАР {alternateCriterion.Disturbance?.Number}" +
                    emergencyDescription;

                Value = TerminateLine(Value);
                Description = TerminateLine(Description);
            }
        }
    }
}
