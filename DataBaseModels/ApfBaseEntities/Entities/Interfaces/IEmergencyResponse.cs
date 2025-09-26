namespace DataBaseModels.ApfBaseEntities
{
    public interface IEmergencyResponse 
    {
        double? Value { get; set; }

        string Description { get; set; }

        double? MinValue { get; set; }

        double? MaxValue { get; set; }
    }
}
