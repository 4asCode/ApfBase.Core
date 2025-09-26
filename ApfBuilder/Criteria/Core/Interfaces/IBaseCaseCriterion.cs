using DataBaseModels.ApfBaseEntities;

namespace ApfBuilder.Criteria.Core.Interfaces
{
    public interface IBaseCaseCriterion : ICriterion 
    {
        Conditions Condition { get; }
    }
}
