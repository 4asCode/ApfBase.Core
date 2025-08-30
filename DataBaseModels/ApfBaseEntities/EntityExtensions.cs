using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities
{
    public static class EntityExtensions
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

        private static readonly Func<List<Task>, Task> Complited = 
            async (collection) =>
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    await collection[i];
                }
            };
    }
}
