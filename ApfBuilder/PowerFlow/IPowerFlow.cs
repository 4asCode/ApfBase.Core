using ApfBuilder.Criteria.Core.Interfaces;

namespace ApfBuilder.PowerFlow
{
    public interface IPowerFlow
    {
        PowerFlowKind Kind { get; }

        ICriterion[] Criteria { get; }

        string Value { get; }

        string Description { get; }
    }
}
