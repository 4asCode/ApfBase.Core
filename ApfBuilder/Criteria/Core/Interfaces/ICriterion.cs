namespace ApfBuilder.Criteria.Core.Interfaces
{
    public interface ICriterion
    {
        string Name { get; }

        double? Value{ get; }

        double? MinValue { get; }

        double? MaxValue { get; }

        double? ComplexMaxValue { get; }

        double? ComplexMinValue { get; }

        int? RoundValue { get; }

        CriterionType Type { get; }
    }
}
