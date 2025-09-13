using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    [ReferenceDataEntity]
    public partial class FrequencyPowerFlow : IEntity
    {
        public void Remove()
        {
            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                var dbSet = context.Set<FrequencyPowerFlow>();

                var removeEntity = dbSet.Find(Id);

                if (removeEntity != null)
                {
                    dbSet.Remove(removeEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}
