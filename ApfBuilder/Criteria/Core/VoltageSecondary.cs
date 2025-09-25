using ApfBuilder.Criteria.Core.Interfaces;
using DataBaseModels.ApfBaseEntities;
using Exceptions.ApfBuilder;
using System;
using static ApfBuilder.Criteria.CriterionAttribute;

namespace ApfBuilder.Criteria.Core
{
    [SecondaryAllowablePF]
    public sealed class VoltageSecondary : CriterionBase, ISecondaryCriterion
    {
        public static ICriterion Create(PreFaultConditions preF)
             => new VoltageSecondary(preF);

        public override CriterionType Type
            => CriterionType.VoltageSecondary;

        public string Postfix { get; }

        public Conditions Condition { get; }

        private VoltageSecondary(PreFaultConditions preF)
            : base
            (
                  preF?.BranchGroupVsBranchGroupScheme
                    ?.BranchGroup
                    ?.RoundValue,
                  preF.VoltagePowerFlow - preF.IrOscExpressions
                    ?? preF.VoltagePowerFlow,
                  preF.ConditionsVoltage
            )
        {
            try
            {
                Name = "15% U";
                Postfix = "*";
                Condition = preF.ConditionsVoltage;
            }
            catch (Exception ex)
            {
                throw new CriterionException(
                    $"Ошибка создания критерия '{Type}'", ex);
            }
        }
    }
}
