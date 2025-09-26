using ApfBuilder.Criteria.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

            var isNeedPrefix = Criteria.Skip(1).Any();

            Value = GetValuePrefix(
                Value.TrimEnd(' ', ';', '\n'), isNeedPrefix
            );

            Description = GetDescriptionPrefix(
                Description.TrimEnd(' ', ';', '\n'), isNeedPrefix
            );
        }
    }
}
