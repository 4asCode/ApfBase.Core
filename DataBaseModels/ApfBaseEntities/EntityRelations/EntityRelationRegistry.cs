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
        private static IReadOnlyList<EntityRelationMetadata> _relationsMap 
            = new List<EntityRelationMetadata>()
        {
            #region AOPORelations
            new EntityRelationMetadata
            {
                EntityType = typeof(AOPO),
                RelatedEntityType = typeof(BranchGroup),
                NavigationProperty = "BranchGroupProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(AOPO),
                RelatedEntityType = typeof(Seasons),
                NavigationProperty = "SeasonsProxy",
                RelationKind = RelationKind.OneToMany
            },
            #endregion AOPORelations
            #region AOSNRelations
            new EntityRelationMetadata
            {
                EntityType = typeof(AOSN),
                RelatedEntityType = typeof(BranchGroup),
                NavigationProperty = "BranchGroupProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(AOSN),
                RelatedEntityType = typeof(Seasons),
                NavigationProperty = "SeasonsProxy",
                RelationKind = RelationKind.OneToMany
            },
            #endregion AOSNRelations
            #region APNURelations
            new EntityRelationMetadata
            {
                EntityType = typeof(APNU),
                RelatedEntityType = typeof(BranchGroup),
                NavigationProperty = "BranchGroupProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(APNU),
                RelatedEntityType = typeof(Seasons),
                NavigationProperty = "SeasonsProxy",
                RelationKind = RelationKind.OneToMany
            },
            #endregion APNURelations
            #region ARPMRelations
            new EntityRelationMetadata
            {
                EntityType = typeof(ARPM),
                RelatedEntityType = typeof(BranchGroup),
                NavigationProperty = "BranchGroupProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(ARPM),
                RelatedEntityType = typeof(Seasons),
                NavigationProperty = "SeasonsProxy",
                RelationKind = RelationKind.OneToMany
            },
            #endregion ARPMRelations
            #region SingleRelations
            new EntityRelationMetadata
            {
                EntityType = typeof(BoundingElements),
                RelatedEntityType = typeof(BranchGroup),
                NavigationProperty = "BranchGroupProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(BranchGroup),
                RelatedEntityType = typeof(Annex),
                NavigationProperty = "AnnexProxy",
                RelationKind = RelationKind.ManyToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(BranchGroupScheme),
                RelatedEntityType = typeof(BranchGroup),
                NavigationProperty = "BranchGroupProxy",
                RelationKind = RelationKind.ManyToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(Conditions),
                RelatedEntityType = typeof(BranchGroup),
                NavigationProperty = "BranchGroupProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(Disturbances),
                RelatedEntityType = typeof(BranchGroup),
                NavigationProperty = "BranchGroupProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(Equipment),
                RelatedEntityType = typeof(AggregatedEquipment),
                NavigationProperty = "AggregatedEquipmentProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(FrequencyPowerFlow),
                RelatedEntityType = typeof(Conditions),
                NavigationProperty = "ConditionsProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(Management),
                RelatedEntityType = typeof(ManagementTasks),
                NavigationProperty = "ManagementTasksProxy",
                RelationKind = RelationKind.OneToMany
            },
            #endregion SingleRelations
            #region PreFaultConditionsRelations
            new EntityRelationMetadata
            {
                EntityType = typeof(PreFaultConditions),
                RelatedEntityType = typeof(Seasons),
                NavigationProperty = "SeasonsProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PreFaultConditions),
                RelatedEntityType = typeof(Temperature),
                NavigationProperty = "TemperatureProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PreFaultConditions),
                RelatedEntityType = typeof(BoundingElements),
                NavigationProperty = "BoundingElementsProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PreFaultConditions),
                RelatedEntityType = typeof(InfluencingEquipment),
                NavigationProperty = "InfluencingEquipmentProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PreFaultConditions),
                RelatedEntityType = typeof(Conditions),
                NavigationProperty = "ConditionsStaticProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PreFaultConditions),
                RelatedEntityType = typeof(Conditions),
                NavigationProperty = "ConditionsCurrentProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PreFaultConditions),
                RelatedEntityType = typeof(Conditions),
                NavigationProperty = "ConditionsVoltageProxy",
                RelationKind = RelationKind.OneToMany
            },
            #endregion PreFaultConditionsRelations
            #region PostFaultConditionsRelations
            new EntityRelationMetadata
            {
                EntityType = typeof(PostFaultConditions),
                RelatedEntityType = typeof(Disturbances),
                NavigationProperty = "DisturbancesProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PostFaultConditions),
                RelatedEntityType = typeof(BoundingElements),
                NavigationProperty = "BoundingElementsProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PostFaultConditions),
                RelatedEntityType = typeof(Conditions),
                NavigationProperty = "ConditionsProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PostFaultConditions),
                RelatedEntityType = typeof(AOPO),
                NavigationProperty = "AOPOProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PostFaultConditions),
                RelatedEntityType = typeof(APNU),
                NavigationProperty = "APNUProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PostFaultConditions),
                RelatedEntityType = typeof(ARPM),
                NavigationProperty = "ARPMProxy",
                RelationKind = RelationKind.OneToMany
            },
            new EntityRelationMetadata
            {
                EntityType = typeof(PostFaultConditions),
                RelatedEntityType = typeof(AOSN),
                NavigationProperty = "AOSNProxy",
                RelationKind = RelationKind.OneToMany
            }
            #endregion PostFaultConditionsRelations
        };

        public static IEnumerable<EntityRelationMetadata> GetRelation(
            Type source) => _relationsMap.Where(
                x => x.EntityType == source);
    }
}
