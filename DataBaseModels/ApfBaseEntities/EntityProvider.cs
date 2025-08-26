using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities
{
    public class EntityProvider
    {
        public static EntityMetadata<T> GetMetadataEntity<T>(
            T _, bool isLazyLoadingEnabled = false)
            where T : class, IEntity
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

        public static BindingList<TEntity> GetEntity<TEntity>(
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
            catch (EntityCommandExecutionException)
            {
                throw;
            }
        }
    }
}
