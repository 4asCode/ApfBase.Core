using DataBaseModels.ApfBaseEntities;
using System.Collections.Generic;

namespace ApfBuilder.Criteria.Core.Interfaces
{
    public interface IEmergencyResponseCriterion : ICriterion 
    {
        IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

        Conditions Condition { get; }

        Disturbances Disturbance { get; }

        double? MinValueER { get; }

        double? MaxValueER { get; }
    }
}
