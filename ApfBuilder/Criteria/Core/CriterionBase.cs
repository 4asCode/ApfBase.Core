using DataBaseModels.ApfBaseEntities;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApfBuilder.Criteria.Core.Interfaces;
using System.Threading.Tasks;

namespace ApfBuilder.Criteria.Core
{
    public abstract class CriterionBase : ICriterion
    {
        public string Name { get; protected set; }

        public double? Value { get; protected set; }

        public double? MinValue { get; protected set; }

        public double? MaxValue { get; protected set; }

        public abstract CriterionType Type { get; }

        protected CriterionBase() { }

        protected CriterionBase(double? baseValue) : this()
        {
            Value = baseValue.Round();

            MinValue = Value;

            MaxValue = Value;
        }

        protected CriterionBase(
            double? baseValue,
            Conditions conditions
            )
            : this(baseValue)
        {
            MinValue = conditions?.MinValue == null
                ? Value
                : Value + conditions.MinValue.Round();

            MaxValue = conditions?.MaxValue == null
                ? Value
                : Value + conditions.MaxValue.Round();
        }
    }
}
