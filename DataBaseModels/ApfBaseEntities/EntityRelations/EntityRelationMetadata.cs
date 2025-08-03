using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities.EntityRelations
{
    public class EntityRelationMetadata
    {
        public Type EntityType { get; set; }     
        
        public Type RelatedEntityType { get; set; }

        public string NavigationProperty { get; set; }

        public RelationKind RelationKind { get; set; }
    }
}
