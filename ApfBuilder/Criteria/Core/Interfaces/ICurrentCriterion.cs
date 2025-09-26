using DataBaseModels.ApfBaseEntities;

namespace ApfBuilder.Criteria.Core.Interfaces
{
    public interface ICurrentCriterion : ICriterion 
    {
        BoundingElements Bounding { get; }
    }
}
