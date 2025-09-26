using Exceptions.DataBaseModels;
using System;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    [ReferenceDataEntity]
    public partial class Equipment : IEntity, IEquipment, IComparable<Equipment>
    {
        public override string ToString()
        {
            return Name?.ToString();
        }

        public int CompareTo(Equipment other)
        {
            if (ReferenceEquals(other, null)) return 1;

            return Id < other.Id ? -1 : (Id > other.Id ? 1 : 0);
        }

        public override bool Equals(object other)
        {
            return other is Equipment ae && Id.Equals(ae.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void Remove()
        {
            try
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var dbSet = context.Set<Equipment>();

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
