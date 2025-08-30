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
    public sealed class VoltageSecondary : CriterionBase, ISecondaryCriterion
    {
        public static ICriterion Create(PreFaultConditions preF)
             => new VoltageSecondary(preF);

        public override CriterionType Type
            => CriterionType.VoltageSecondary;

        public string Postfix { get; }

        private VoltageSecondary(PreFaultConditions preF)
            : base
            (
                  preF.VoltagePowerFlow - preF.IrOscExpressions
                    ?? preF.VoltagePowerFlow
            )
        {
            Name = "15% U";
            Postfix = "*";
        }
    }
}
