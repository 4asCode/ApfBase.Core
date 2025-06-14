using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Serialize;
using Stream;

namespace RoslynScripting
{
    public class AssemblyInfo
    {
        private const string _settingPath =
            "setting//Scripts//AssemblyInfo//assembly.json";

        public IEnumerable<Assembly> Assemblies { get; private set; }

        public Type[] References { get; set; }

        public string[] Namespaces { get; set; }

        public void LoadAssembly()
        {
            var read = new Reader().Read(_settingPath);

            var assembly = new JsonSerializer().
                Deserialize<AssemblyInfo>(read);

            References = assembly.References;
            Namespaces = assembly.Namespaces;

            Assemblies = References.Select(t => t.Assembly);
        }

        public IEnumerable<string> GetClassesFromAssembly(
            IEnumerable<Assembly> assemblies)
        {
            var classNames = new HashSet<string>();

            foreach (var assembly in assemblies)
            {
                try
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.IsClass &&
                            !string.IsNullOrEmpty(type.Name))
                        {
                            classNames.Add(type.Name);
                        }
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                    foreach (var type in ex.Types)
                    {
                        if (type != null &&
                            type.IsClass &&
                            !string.IsNullOrEmpty(type.Name))
                        {
                            classNames.Add(type.Name);
                        }
                    }
                }
            }

            return classNames;
        }

        public IEnumerable<string> GetInterfaceFromAssembly(
            IEnumerable<Assembly> assemblies)
        {
            var interfaceNames = new HashSet<string>();

            foreach (var assembly in assemblies)
            {
                try
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.IsInterface &&
                            !string.IsNullOrEmpty(type.Name))
                        {
                            interfaceNames.Add(type.Name);
                        }
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                    foreach (var type in ex.Types)
                    {
                        if (type != null &&
                            type.IsInterface &&
                            !string.IsNullOrEmpty(type.Name))
                        {
                            interfaceNames.Add(type.Name);
                        }
                    }
                }
            }

            return interfaceNames;
        }

        public IEnumerable<string> GetMethodsFromAssembly(
            IEnumerable<Assembly> assemblies, IEnumerable<string> namespaces)
        {
            var methodList = new List<string>();

            foreach (var asm in assemblies)
            {
                try
                {
                    var types = asm.GetTypes().Where(
                        t => namespaces.Contains(t.Namespace));

                    foreach (var type in types)
                    {
                        var methods = type.GetMethods(
                            BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.Instance
                            );

                        foreach (var method in methods)
                        {
                            methodList.Add(method.Name);
                        }
                    }
                }
                catch
                {
                    // Игнорируем ошибки загрузки типов
                }
            }
            return methodList;
        }

        public IEnumerable<string> GetPropertiesFromAssembly(
            IEnumerable<Assembly> assemblies, IEnumerable<string> namespaces)
        {
            var propertyList = new List<string>();

            foreach (var asm in assemblies)
            {
                try
                {
                    var types = asm.GetTypes().Where(
                        t => namespaces.Contains(t.Namespace));

                    foreach (var type in types)
                    {
                        var properties = type.GetProperties(
                            BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.Instance
                            );

                        foreach (var property in properties)
                        {
                            propertyList.Add(property.Name);
                        }
                    }
                }
                catch
                {
                    // Игнорируем ошибки загрузки типов
                }
            }
            return propertyList;
        }
    }
}
