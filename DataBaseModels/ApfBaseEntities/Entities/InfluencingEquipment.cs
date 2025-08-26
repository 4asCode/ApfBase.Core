using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    [ReferenceDataEntity]
    public partial class InfluencingEquipment : IEntity, IUidProvider, IComparable<InfluencingEquipment>
    {
        public override string ToString()
        {
            return Name?.ToString();
        }

        public int CompareTo(InfluencingEquipment infEquipment) 
            => string.Compare(Name, infEquipment.Name);

        public override bool Equals(object other)
        {
            return other is InfluencingEquipment ae && Uid.Equals(ae.Uid);
        }

        public override int GetHashCode()
        {
            return Uid.GetHashCode();
        }

        public void Remove()
        {
            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                var dbSet = context.Set<InfluencingEquipment>();

                var removeEntity = dbSet.Find(Uid);

                if (removeEntity != null)
                {
                    dbSet.Remove(removeEntity);
                    context.SaveChanges();
                }
            }
        }

        public void GenerateUid()
        {
            if (Uid != Guid.Empty) return;

            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                Uid = Guid.NewGuid();

                var dbSet = context.Set<InfluencingEquipment>();

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
