using Exceptions.DataBaseModels;
using System;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    [ReferenceDataEntity]
    public partial class BranchGroup : IEntity, IUidProvider
    {
        public BranchGroup(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name?.ToString();
        }

        public void Remove()
        {
            try
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var dbSet = context.Set<BranchGroup>();

                    var removeEntity = dbSet.Find(Uid);

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

        public void GenerateUid()
        {
            if (Uid != Guid.Empty) return;

            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                Uid = Guid.NewGuid();

                var dbSet = context.Set<BranchGroup>();

                var uid = dbSet.Find(Uid)?.Uid;

                while (uid != null)
                {
                    Uid = Guid.NewGuid();
                    uid = dbSet.Find(Uid)?.Uid;
                }
            }
        }
    }
}
