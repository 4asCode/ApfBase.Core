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
    public partial class Annex : IEntity
    {
        public Annex(string value)
        {
            Name = value;
        }

        public override string ToString()
        {
            return Name?.ToString();
        }

        public void Remove()
        {
            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                var dbSet = context.Set<Annex>();

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
