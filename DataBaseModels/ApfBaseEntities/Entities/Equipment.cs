using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    [ReferenceDataEntity]
    public partial class Equipment : IEntity, IComparable<Equipment>
    {
        public override string ToString()
        {
            return Name?.ToString();
        }

        public int CompareTo(Equipment equipment)
        {
            if (this.Id < equipment.Id)
                return -1;
            else if (this.Id > equipment.Id)
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
            else if (!(other is Equipment))
            {
                return false;
            }

            return Equals((other as Equipment).Id, Id);
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
                var dbSet = context.Set<Equipment>();

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
