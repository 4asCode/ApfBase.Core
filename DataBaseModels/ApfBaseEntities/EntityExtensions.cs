using Serialize;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;

namespace DataBaseModels.ApfBaseEntities
{
    public static partial class EntityExtensions
    {
        private static volatile object _locker = new object();

        private static volatile List<Task> _tasks = new List<Task>();

        public static async Task SaveAsync(
            this IEntity entity)
        {
            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                _tasks.Add(
                    Task.Run(() =>
                    {
                        lock (_locker)
                        {
                            if (entity is IUidProvider entityProvider)
                            {
                                entityProvider.GenerateUid();
                            }

                            context.SingleMerge(entity);

                            context.SaveChanges();
                        }
                    })
                );

                await Complited.Invoke(_tasks);

                if (_tasks.All(t => t.IsCompleted))
                {
                    _tasks.Clear();
                }
            }
        }

        public static async Task SaveAsync(
            this IEnumerable<IEntity> entities)
        {
            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                _tasks.Add(
                    Task.Run(() =>
                    {
                        lock (_locker)
                        {
                            foreach (var entity in entities)
                            {
                                if (entity is IUidProvider entityProvider)
                                {
                                    entityProvider.GenerateUid();
                                }

                                context.SingleMerge(entity);
                            }

                            context.SaveChanges();
                        }
                    })
                );

                await Complited.Invoke(_tasks);

                if (_tasks.All(t => t.IsCompleted))
                {
                    _tasks.Clear();
                }
            }
        }

        public static void Save(this IEntity entity)
        {
            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                if (entity is IUidProvider entityProvider)
                {
                    entityProvider.GenerateUid();
                }

                context.SingleMerge(entity);

                context.SaveChanges();
            }
        }

        public static void Save(this IEnumerable<IEntity> entities)
        {
            using (var context = new ApfBaseContext(
                DataBaseConnection.ConnectionString))
            {
                foreach (var entity in entities)
                {
                    if (entity is IUidProvider entityProvider)
                    {
                        entityProvider.GenerateUid();
                    }

                    context.SingleMerge(entity);
                }

                context.SaveChanges();
            }
        }

        private static Func<List<Task>, Task> Complited = async (collection) =>
        {
            for (int i = 0; i < collection.Count; i++)
            {
                await collection[i];
            }
        };
    }
}
