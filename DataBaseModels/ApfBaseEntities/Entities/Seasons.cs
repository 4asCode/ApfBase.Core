using Exceptions.DataBaseModels;
using System;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    [ReferenceDataEntity]
    public partial class Seasons : IEntity
    {
        public override string ToString()
        {
            return Value?.ToString();
        }

        public void Remove()
        {
            try
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var dbSet = context.Set<Seasons>();

                    var removeEntity = dbSet.Find(Id);

                    if (removeEntity != null)
                    {
                        dbSet.Remove(removeEntity);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new EntityQueryException(
                    $"Ошибка при удалении сущности " +
                    $"{this.GetType().FullName}", ex
                    );
            }
        }
    }
}
