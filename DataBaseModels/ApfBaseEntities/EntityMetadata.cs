using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities
{
    public class EntityMetadata<T> where T : class, IEntity
    {
        public BindingList<T> Entities { get; set; }

        public ApfBaseContext Context { get; set; }
    }
}
