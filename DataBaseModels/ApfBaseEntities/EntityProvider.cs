using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using Exceptions.DataBaseModels;

namespace DataBaseModels.ApfBaseEntities
{
    public class EntityProvider
    {
        public static EntityMetadata<T> GetMetadataEntity<T>(
            T _, bool isLazyLoadingEnabled = true)
            where T : class, IEntity
        {
            try
            {
                var context = new ApfBaseContext(
                    DataBaseConnection.ConnectionString);
                context.Configuration.LazyLoadingEnabled =
                    isLazyLoadingEnabled;

                var data = GetEntity<T>(context);

                return new EntityMetadata<T>
                {
                    Entities = data,
                    Context = context
                };
            }
            catch (Exception ex)
            {
                throw new EntityQueryException(
                    $"Ошибка при запросе сущности " +
                    $"{typeof(T).FullName}", ex
                    );
            }
        }

        public static IList<TEntity> GetEntity<TEntity>(
            ApfBaseContext context,
            Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity
        {
            try
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (filter != null) query = query.Where(filter);

                var data = new BindingList<TEntity>(query.ToList())
                {
                    AllowNew = true,
                    AllowEdit = true,
                    AllowRemove = true
                };

                return data;
            }
            catch (EntityCommandExecutionException ex)
            {
                throw new EntityCommandExecutionException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new EntityQueryException(
                    $"Ошибка при запросе сущности " +
                    $"{typeof(TEntity).FullName}", ex
                    );
            }
        }
    }
}
