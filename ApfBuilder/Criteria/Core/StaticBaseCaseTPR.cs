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
    [AllowablePF]
    public sealed class StaticBaseCaseTPR : CriterionBase, IBaseCaseCriterion
    {
        public static ICriterion Create(PreFaultConditions preF)
             => new StaticBaseCaseTPR(preF);

        public override CriterionType Type
            => CriterionType.StaticBaseCaseTPR;

        private StaticBaseCaseTPR(PreFaultConditions preF)
            : base
            (
                  preF.TprPowerFlow - preF.IrOscExpressions
                    ?? preF.TprPowerFlow
            )
        {
            Name = "20% P, исходная схема";
        }
    }
}
