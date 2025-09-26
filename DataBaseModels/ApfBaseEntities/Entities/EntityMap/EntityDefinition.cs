using System;

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
