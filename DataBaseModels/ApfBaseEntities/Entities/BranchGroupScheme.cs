using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    [ReferenceDataEntity]
    public partial class BranchGroupScheme : IEntity, IUidProvider
    {
        public override string ToString()
        {
            return Name?.ToString();
        }

        public void Remove()
        {
            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                var dbSet = context.Set<BranchGroupScheme>();

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

                var dbSet = context.Set<BranchGroupScheme>();
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
