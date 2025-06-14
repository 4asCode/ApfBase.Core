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
        public static BindingList<TEntity> GetEntity<TEntity>(
            ApfBaseContext context) where TEntity : class, IEntity
        {
            var listData = new BindingList<TEntity>()
            {
                AllowNew = true,
                AllowEdit = true,
                AllowRemove = true
            };

            try
            {
                var table = SetEntity<TEntity>(context);
                table.ToList().ForEach(el => listData.Add(el));

                return listData;
            }
            catch (EntityCommandExecutionException)
            {
                throw;
            }
        }

        public static BindingList<TEntity> GetEntity<TEntity>(
            ApfBaseContext context,
            Expression<Func<TEntity, bool>> filter) 
            where TEntity : class, IEntity
        {
            var listData = new BindingList<TEntity>()
            {
                AllowNew = true,
                AllowEdit = true,
                AllowRemove = true
            };

            try
            {
                var table = SetEntityCondition(context, filter);
                table.ToList().ForEach(el => listData.Add(el));

                return listData;
            }
            catch (EntityCommandExecutionException)
            {
                throw;
            }
        }

        public static BindingList<TEntity> GetEntity<TEntity>(
            ApfBaseContext context,
            Expression<Func<TEntity, bool>> filterOne, 
            Expression<Func<TEntity, bool>> filterTwo) 
            where TEntity : class, IEntity
        {
            var listData = new BindingList<TEntity>()
            {
                AllowNew = true,
                AllowEdit = true,
                AllowRemove = true
            };

            try
            {
                var table = SetEntityConditions(
                    context, filterOne, filterTwo);
                table.ToList().ForEach(el => listData.Add(el));

                return listData;
            }
            catch (EntityCommandExecutionException)
            {
                throw;
            }
        }

        public static BindingList<TResult> GetClassObject<TEntity, TResult>(
            ApfBaseContext context,
            Expression<Func<TEntity, TResult>> filter) 
            where TEntity : class, IEntity where TResult : class
        {
            var listData = new BindingList<TResult>()
            {
                AllowNew = true,
                AllowEdit = true,
                AllowRemove = true
            };

            try
            {
                var table = SelectSValue(context, filter);
                var notNull = table.Where(v => v != null);
                notNull.ToList().ForEach(el => listData.Add(el));

                return listData;
            }
            catch (EntityCommandExecutionException)
            {
                throw;
            }
        }

        public static BindingList<TResult?> GetStructObject<TEntity, TResult>(
            ApfBaseContext context,
            Expression<Func<TEntity, TResult?>> filter) 
            where TEntity : class, IEntity 
            where TResult : struct
        {
            var listData = new BindingList<TResult?>()
            {
                AllowNew = true,
                AllowEdit = true,
                AllowRemove = true
            };

            try
            {
                var table = SelectTValue(context, filter);
                table.ToList().ForEach(el => listData.Add(el));

                return listData;
            }
            catch (EntityCommandExecutionException)
            {
                throw;
            }
        }

        private static IQueryable<TEntity> SetEntity<TEntity>(
            ApfBaseContext context) where TEntity : class, IEntity
        {
            return context.Set<TEntity>();
        }

        private static IQueryable<TEntity> SetEntityCondition<TEntity>(
            ApfBaseContext context,
            Expression<Func<TEntity, bool>> filter) 
            where TEntity : class, IEntity
        {
            return context.Set<TEntity>().Where(filter);
        }

        private static IQueryable<TEntity> SetEntityConditions<TEntity>(
            ApfBaseContext context,
            Expression<Func<TEntity, bool>> filterOne,
            Expression<Func<TEntity, bool>> filterTwo) 
            where TEntity : class, IEntity
        {
            return context.Set<TEntity>().Where(filterOne).Where(filterTwo);
        }

        private static IQueryable<TResult> SelectSValue<TEntity, TResult>(
            ApfBaseContext context,
            Expression<Func<TEntity, TResult>> filter)
            where TEntity : class, IEntity 
            where TResult : class
        {
            return context.Set<TEntity>().Select(filter);
        }

        private static IQueryable<TResult?> SelectTValue<TEntity, TResult>(
            ApfBaseContext context,
            Expression<Func<TEntity, TResult?>> filter)
            where TEntity : class, IEntity 
            where TResult : struct
        {
            return context.Set<TEntity>().Select(filter);
        }
    }
}
