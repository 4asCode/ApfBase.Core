using DataBaseModels.ApfBaseEntities;

namespace ApfBuilder.Criteria.Core.Interfaces
{
    public interface ISecondaryCriterion : ICriterion
    {
        string Postfix { get; }

        Conditions Condition { get; }
    }
}
