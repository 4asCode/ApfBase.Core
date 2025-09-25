using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApfBuilder.Criteria.Core.Interfaces;
using static ApfBuilder.Criteria.CriterionAttribute;
using Exceptions;

namespace ApfBuilder.Criteria.Core
{
    [AllowablePF]
    public sealed class StaticBaseCaseTPR : CriterionBase, IBaseCaseCriterion
    {
        public static ICriterion Create(PreFaultConditions preF)
             => new StaticBaseCaseTPR(preF);

        public override CriterionType Type
            => CriterionType.StaticBaseCaseTPR;

        public Conditions Condition { get; }

        private StaticBaseCaseTPR(PreFaultConditions preF)
            : base
            (
                  preF?.BranchGroupVsBranchGroupScheme
                      ?.BranchGroup
                      ?.RoundValue,
                  preF.TprPowerFlow - preF.IrOscExpressions
                    ?? preF.TprPowerFlow,
                  preF.ConditionsStatic
            )
        {
            try
            {
                Name = "20% P, исходная схема";
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
