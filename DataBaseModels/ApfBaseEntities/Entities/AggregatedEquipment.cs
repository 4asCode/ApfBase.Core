using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace DataBaseModels.ApfBaseEntities
{
    [ReferenceDataEntity]
    public partial class AggregatedEquipment : IEntity, IComparable<AggregatedEquipment>
    {
        public AggregatedEquipment(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name?.ToString();
        }

        public int CompareTo(AggregatedEquipment other)
        {
            if (ReferenceEquals(other, null)) return 1;

            return Id < other.Id ? -1 : (Id > other.Id ? 1 : 0);
        }

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
    }
}
