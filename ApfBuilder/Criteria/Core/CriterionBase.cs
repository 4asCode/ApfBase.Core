using ApfBuilder.Criteria.Core.Interfaces;
using DataBaseModels.ApfBaseEntities;
using Extensions;

namespace ApfBuilder.Criteria.Core
{
    public abstract class CriterionBase : ICriterion
    {
        public string Name { get; protected set; }

        public double? Value { get; protected set; }

        public double? MinValue { get; protected set; }

        public double? MaxValue { get; protected set; }

        public int? RoundValue { get; }

        public abstract CriterionType Type { get; }

        protected CriterionBase() { }

        protected CriterionBase(int? roundParam) : this()
        {
            RoundValue = roundParam;
        }

        protected CriterionBase(int? roundParam, double? baseValue)
            : this(roundParam)
        {
            Value = baseValue.Round(roundParam);

            MinValue = Value;

            MaxValue = Value;
        }

        protected CriterionBase(
            int? roundParam,
            double? baseValue,
            Conditions conditions
            )
            : this(roundParam, baseValue)
        {
            MinValue = conditions?.MinValue == null
                ? Value
                : Value + conditions.MinValue.Round(roundParam);

            MaxValue = conditions?.MaxValue == null
                ? Value
                : Value + conditions.MaxValue.Round(roundParam);
        }
    }
}
