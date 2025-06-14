using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    public partial class InfluencingEquipment : IEntity, IComparable<InfluencingEquipment>
    {
        public override string ToString()
        {
            return Name?.ToString();
        }

        public int CompareTo(InfluencingEquipment infEquipment)
        {
            if (this.Id < infEquipment.Id)
                return -1;
            else if (this.Id > infEquipment.Id)
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
            else if (!(other is InfluencingEquipment))
            {
                return false;
            }

            return Equals((other as InfluencingEquipment).Id, Id);
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
                var dbSet = context.Set<InfluencingEquipment>();

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
