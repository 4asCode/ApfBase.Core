using ApfBuilder.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Text;
using ApfBuilder.Criteria.Core.Interfaces;
using System.Threading.Tasks;

namespace ApfBuilder.PowerFlow
{
    public class PowerFlowForcedState : PowerFlowBase
    {
        public override PowerFlowKind Kind => 
            PowerFlowKind.PowerFlowForcedState;

        public PowerFlowForcedState(IEnumerable<ICriterion> criteria)
            : base(criteria)
        {
            Compose();
        }

        public override void Compose()
        {
            foreach (var criterion in Criteria)
            {
                if (criterion is IBaseCaseCriterion baseCaseCriterion)
                {
                    Value += baseCaseCriterion.Value;
                    Description += baseCaseCriterion.Name;

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

                if (criterion is IEmergencyResponseCriterion complexCriterion)
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
