using Exceptions.DataBaseModels;
using System;
using System.ComponentModel;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    [ReferenceDataEntity]
    public partial class ARPM : IEntity, IEmergencyResponse
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
            try
            {
                using (var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString))
                {
                    var dbSet = context.Set<ARPM>();

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
