using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities.EntityRelations
{
    public static class EntityRelationRegistry
    {
        public static List<EntityRelationMetadata> Relations { get; } 
            = new List<EntityRelationMetadata>()
        {
            new EntityRelationMetadata
            {
                EntityType = typeof(Annex),
                RelatedEntityType = typeof(BranchGroup),
                NavigationProperty = "BranchGroup",
                RelationKind = RelationKind.ManyToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(BoundingElements),
                RelatedEntityType = typeof(BranchGroup),
                NavigationProperty = "BranchGroup",
                RelationKind = RelationKind.ManyToOne
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(BoundingElements),
                RelatedEntityType = typeof(PreFaultConditions),
                NavigationProperty = "PreFaultConditions",
                RelationKind = RelationKind.OneToMany
            },
        };

        public static IEnumerable<EntityRelationMetadata> GetRelation(
            Type source) => Relations.Where(
                x => x.EntityType == source);
    }
}
