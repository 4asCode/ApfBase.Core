using Exceptions.DataBaseModels;
using System;

namespace DataBaseModels.ApfBaseEntities
{
    public partial class APF : IEntity
    {
        public void Remove()
        {
            try
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var dbSet = context.Set<APF>();

                    var removeEntity = dbSet.Find(
                        BranchGroupVsBranchGroupSchemeId,
                        PreFaultConditionsId
                        );

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
