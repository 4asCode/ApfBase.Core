using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities.EntityRelations
{
    public static partial class EntityExtensions
    {
        public static IEnumerable<IEntity> LoadRelatedEntities(
            this IEntity entity, DbContext context)
        {
            var realEntityType = ObjectContext
                .GetObjectType(entity.GetType()
                );

            var relationsMeta = EntityRelationRegistry
                .GetRelation(realEntityType
                );

            if (!relationsMeta.Any()) yield break;

            foreach (var meta in relationsMeta)
            {
                switch (meta.RelationKind)
                {
                    case RelationKind.ManyToMany:
                    case RelationKind.OneToMany:
                        {
                            var nav = context
                                .Entry(entity)
                                .Collection(meta.NavigationProperty);
                            nav.Load();


                            if (
                                entity
                                .GetType()
                                .GetProperty(meta.NavigationProperty)
                                .GetValue(entity) is 
                                IEnumerable<IEntity> relatedList
                               )
                            {
                                foreach (var relation in relatedList)
                                {
                                    yield return relation;
                                }
                            }
                            break;
                        }

                    case RelationKind.ManyToOne:
                    case RelationKind.OneToOne:
                        {
                            var nav = context
                                .Entry(entity)
                                .Reference(meta.NavigationProperty);
                            nav.Load();

                            if (
                                entity
                                .GetType()
                                .GetProperty(meta.NavigationProperty)
                                .GetValue(entity) is IEntity value
                               ) yield return value;
                            break;
                        }

                    default:
                        throw new InvalidOperationException(
                            $"Неизвестный тип связи: {meta.RelationKind}"
                            );
                }
            }
        }

        public static void SaveRelatedEntities(
            this IEntity entity,
            IEnumerable<IEntity> relatedEntities,
            DbContext context)
        {
            var realEntityType = ObjectContext
                .GetObjectType(entity.GetType()
                );

            var relationsMeta = EntityRelationRegistry
                .GetRelation(realEntityType);

            if (!relationsMeta.Any()) return;

            foreach (var meta in relationsMeta)
            {
                switch (meta.RelationKind)
                {
                    case RelationKind.ManyToMany:
                    case RelationKind.OneToMany:
                        {
                            var navProp = entity.GetType()
                                .GetProperty(meta.NavigationProperty);

                            if (navProp == null ||
                                    !typeof(IEnumerable)
                                    .IsAssignableFrom(navProp.PropertyType)
                                )
                                continue;

                            var listType = typeof(List<>)
                                .MakeGenericType(meta.RelatedEntityType);

                            var newList = (IList)Activator
                                .CreateInstance(listType);

                            foreach (var related in relatedEntities)
                            {
                                newList.Add(related);
                            }

                            navProp.SetValue(entity, newList);

                            break;
                        }

                    case RelationKind.ManyToOne:
                    case RelationKind.OneToOne:
                        {
                            var navProp = entity.GetType()
                                .GetProperty(meta.NavigationProperty);

                            if (navProp == null) continue;

                            var related = relatedEntities.FirstOrDefault();
                            navProp.SetValue(entity, related);

                            break;
                        }

                    default:
                        throw new InvalidOperationException(
                            $"Неизвестный тип связи: {meta.RelationKind}"
                            );
                }
            }
        }
    }
}
