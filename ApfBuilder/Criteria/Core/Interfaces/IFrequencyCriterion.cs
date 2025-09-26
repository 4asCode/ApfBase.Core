using DataBaseModels.ApfBaseEntities;

namespace ApfBuilder.Criteria.Core.Interfaces
{
    public interface IFrequencyCriterion : ICriterion
    {
        (string Value, string Description) FullValue { get; }

        FrequencyPowerFlow FrequencyPowerFlow { get; }

        Disturbances Disturbance { get; }
    }
}
