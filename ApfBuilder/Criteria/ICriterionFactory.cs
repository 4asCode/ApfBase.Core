using ApfBuilder.Criteria.Core.Interfaces;

namespace ApfBuilder.Criteria
{
    public interface ICriterionFactory
    {
        ICriterion[] BaseStateCriteria { get; }

        ICriterion[] ForcedStateCriteria { get; }
    }
}
