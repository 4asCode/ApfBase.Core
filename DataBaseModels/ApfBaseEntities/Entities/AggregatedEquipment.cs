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

        public int CompareTo(AggregatedEquipment aggregatedEquipment)
        {
            if (this.Id < aggregatedEquipment.Id)
                return -1;
            else if (this.Id > aggregatedEquipment.Id)
                return 1;
            else
                return 0;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            else if (!(other is AggregatedEquipment))
            {
                return false;
            }

            return Equals((other as AggregatedEquipment).Id, Id);
        }

        public override int GetHashCode()
        {
            return new { Id }.GetHashCode();
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
