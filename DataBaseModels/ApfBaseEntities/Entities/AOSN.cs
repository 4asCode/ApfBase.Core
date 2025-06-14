using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    [ReferenceDataEntity]
    public partial class AOSN : IEntity, IEmergencyResponse
    {
        [Browsable(false)]
        public double? Value { get; set; }

        [Browsable(false)]
        public string Description { get; set; }

        [Browsable(false)]
        public double? MinValue { get; set; } = 0;

        [Browsable(false)]
        public double? MaxValue { get; set; }

        public override string ToString()
        {
            return Name?.ToString();
        }

        public void Remove()
        {
            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                var dbSet = context.Set<AOSN>();

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
