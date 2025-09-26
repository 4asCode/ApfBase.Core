using System.Collections.Generic;

namespace DataBaseModels.ApfBaseEntities
{
    public class EntityMetadata<T> where T : class, IEntity
    {
        public IList<T> Entities { get; set; }

        public ApfBaseContext Context { get; set; }
    }
}
