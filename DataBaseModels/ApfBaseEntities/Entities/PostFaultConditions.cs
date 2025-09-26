using Exceptions.DataBaseModels;
using System;

namespace DataBaseModels.ApfBaseEntities
{
    public partial class PostFaultConditions : IEntity, IAPFContextParticipant
    {
        public void Remove()
        {
            try
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var dbSet = context.Set<PostFaultConditions>();

                    var removeEntity = dbSet.Find(
                        BranchGroupVsBranchGroupSchemeId,
                        PreFaultConditionsId,
                        Id
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
