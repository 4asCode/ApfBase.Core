using ApfBuilder.Criteria.Core.Interfaces;
using DataBaseModels.ApfBaseEntities;
using Exceptions.ApfBuilder;
using System;
using static ApfBuilder.Criteria.CriterionAttribute;

namespace ApfBuilder.Criteria.Core
{
    [EmergencyPF]
    public sealed class StaticBaseCaseEPR : CriterionBase, IBaseCaseCriterion
    {
        public static ICriterion CreateStandard(
            PreFaultConditions preF)
        {
            return new StaticBaseCaseEPR
                (
                    preF,
                    preF.EprPowerFlow - preF.IrOscExpressions
                        ?? preF.EprPowerFlow
                );
        }

        public static ICriterion CreateForcedState(
            PreFaultConditions preF)
        {
            return new StaticBaseCaseEPR
                (
                    preF,
                    preF.IrOscExpressions != null
                        ? preF.EprPowerFlow - preF.IrOscExpressions * 2
                        : preF.EprPowerFlow
                );
        }

        public override CriterionType Type
            => CriterionType.StaticBaseCaseEPR;

        public Conditions Condition { get; }

        private StaticBaseCaseEPR(PreFaultConditions preF, double? value)
            : base
            (
                  preF?.BranchGroupVsBranchGroupScheme
                      ?.BranchGroup
                      ?.RoundValue,
                  value
            )
        {
            try
            {
                Name = "8% P, исходная схема";
                Condition = preF.ConditionsStatic;
            }
            catch (Exception ex)
            {
                throw new CriterionException(
                    $"Ошибка создания критерия '{Type}'", ex);
            }
        }
    }
}
