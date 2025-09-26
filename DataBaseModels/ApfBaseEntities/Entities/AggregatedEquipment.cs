using Exceptions.DataBaseModels;
using System;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    [ReferenceDataEntity]
    public partial class AggregatedEquipment : IEntity, IEquipment, IComparable<AggregatedEquipment>
    {
        public AggregatedEquipment(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name?.ToString();
        }

        public int CompareTo(AggregatedEquipment agEq)
            => string.Compare(Name, agEq.Name);

        public override bool Equals(object other)
        {
            return other is AggregatedEquipment ae && Id.Equals(ae.Id);
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
                    var dbSet = context.Set<AggregatedEquipment>();

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
