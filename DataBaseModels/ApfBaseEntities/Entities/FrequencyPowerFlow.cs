using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities
{
    public partial class FrequencyPowerFlow : IEntity
    {
        public void Remove()
        {
            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                var dbSet = context.Set<Seasons>();

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
