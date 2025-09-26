using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        public static IEnumerable<Type> GetAssemblyType<T>() => 
            Assembly.GetExecutingAssembly().GetTypes().Where(
                t => t.IsDefined(typeof(T), true)
                );
    }
}
