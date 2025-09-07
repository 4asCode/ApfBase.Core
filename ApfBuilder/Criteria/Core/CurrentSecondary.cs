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
    [SecondaryAllowablePF]
    public sealed class CurrentSecondary : CriterionBase, ICurrentCriterion, ISecondaryCriterion
    {
        public static ICriterion CreateStandard(
            PreFaultConditions preF)
        {
            return new CurrentSecondary
                (
                    preF,
                    preF.CurrentPowerFlow -
                        preF.IrOscExpressions ??
                        preF.CurrentPowerFlow,
                    "ДДТН"
                );
        }

        public static ICriterion CreateAOPO(
            PreFaultConditions preF)
        {
            return new CurrentSecondary
                (
                    preF,
                    preF.CurrentAOPO -
                        preF.IrOscExpressions ??
                        preF.CurrentAOPO,
                    "ДТН"
                );
        }

        public override CriterionType Type
            => CriterionType.CurrentSecondary;

        public BoundingElements Bounding { get; }

        public Conditions Condition { get; }

        public string Postfix { get; }

        private CurrentSecondary(PreFaultConditions preF, 
            double? value, string name)
            : base
            (
                  value,
                  preF.ConditionsCurrent
            )
        {
            Name = name;
            Postfix = "*";
            Bounding = preF.BoundingElements;
            Condition = preF.ConditionsCurrent;
        }
    }
}
