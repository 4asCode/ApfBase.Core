using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities.Entities.EntityMap
{
    public class EntityDefinition : IDefinition
    {
        public Type EntityType { get; set; }

        public string Caption { get; set; }

        public string Category { get; set; }

        public bool IsReadOnly { get; set; }
    }
}
