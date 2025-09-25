using ApfBuilder.Criteria.Core.Interfaces;
using DataBaseModels.ApfBaseEntities;
using Exceptions.ApfBuilder;
using System;
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
                  preF?.BranchGroupVsBranchGroupScheme
                      ?.BranchGroup
                      ?.RoundValue,
                  value,
                  preF.ConditionsCurrent
            )
        {
            try
            {
                Name = name;
                Postfix = "*";
                Bounding = preF.BoundingElements;
                Condition = preF.ConditionsCurrent;
            }
            catch (Exception ex)
            {
                throw new CriterionException(
                    $"Ошибка создания критерия '{Type}'", ex);
            }
        }
    }
}
