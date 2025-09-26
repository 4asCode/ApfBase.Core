namespace DataBaseModels.ApfBaseEntities.Entities.EntityMap
{
    public interface IMap<T> where T : IDefinition
    {
        T[] Map { get; }
    }
}
