using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities
{
    public class EntityAttribute
    {
        public class ReferenceDataEntityAttribute : Attribute { }

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
        public class ProxyForAttribute : Attribute
        {
            public string TargetPropertyName { get; }

            public ProxyForAttribute(string targetPropertyName)
            {
                TargetPropertyName = targetPropertyName;
            }
        }

        public IEnumerable<IEntity> GetAssemblyInstance<TEntity>()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes()
                .Where(t => t.IsDefined(typeof(TEntity), true));

            return types.Select(
                t =>
                {
                    var instance = Activator.CreateInstance(t);

                    if (instance == null)
                    {
                        throw new ArgumentNullException();
                    }

                    return (IEntity)instance;
                }
            );
        }
    }
}
