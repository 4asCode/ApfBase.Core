using System;

namespace DataBaseModels.ApfBaseEntities.Entities.EntityRelations
{
    public class EntityRelationMetadata
    {
        public Type EntityType { get; set; }     
        
        public Type RelatedEntityType { get; set; }

        public string NavigationProperty { get; set; }

        public RelationKind RelationKind { get; set; }
    }
}
