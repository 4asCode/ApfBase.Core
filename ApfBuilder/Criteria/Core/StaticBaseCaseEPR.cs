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
    [EmergencyPF]
    public sealed class StaticBaseCaseEPR : CriterionBase, IBaseCaseCriterion
    {
        public static ICriterion CreateStandard(
            PreFaultConditions preF)
        {
            return new StaticBaseCaseEPR
                (
                    preF.EprPowerFlow - preF.IrOscExpressions
                        ?? preF.EprPowerFlow
                );
        }

        public static ICriterion CreateForcedState(
            PreFaultConditions preF)
        {
            return new StaticBaseCaseEPR
                (
                    preF.IrOscExpressions != null
                        ? preF.EprPowerFlow - preF.IrOscExpressions * 2
                        : preF.EprPowerFlow
                );
        }

        public override CriterionType Type
            => CriterionType.StaticBaseCaseEPR;

        private StaticBaseCaseEPR(double? value)
            : base(value)
        {
            Name = "8% P, исходная схема";
        }
    }
}
