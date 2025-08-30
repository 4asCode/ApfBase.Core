using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static DataBaseModels.ApfBaseEntities.EntityAttribute;
using DataBaseModels.ApfBaseEntities;
using System.IO;

namespace DataBaseModels.ApfBaseEntities.Entities.EntityMap
{
    public class EntityMap : IMap<EntityDefinition>
    {
        private IReadOnlyDictionary<Type, 
            (string, string, bool)> _map 
            = new Dictionary<Type, 
                (string Caption, string Category, bool ReadOnly)>
            {
                { 
                    typeof(Temperature), 
                    ("Температура", "Справочники", false) 
                },
                { 
                    typeof(Seasons), 
                    ("Сезон", "Справочники", false) 
                },
                { 
                    typeof(Annex), 
                    ("Приложения", "Основные", false) 
                },
                { 
                    typeof(BranchGroup), 
                    ("Сечения", "Основные", false) 
                },
                { 
                    typeof(BranchGroupScheme), 
                    ("Ремонтные схемы", "Основные", false) 
                },
                { 
                    typeof(AggregatedEquipment), 
                    ("Станции/Транзиты", "Оборудование", false) 
                },
                { 
                    typeof(Equipment), 
                    ("Оборудование", "Оборудование", false) 
                },
                { 
                    typeof(InfluencingEquipment), 
                    ("Влияющее оборудование", "Оборудование", true) 
                },
                { 
                    typeof(BoundingElements), 
                    ("Ограничивающие элементы", "Дополнительные", false) 
                },
                { 
                    typeof(Disturbances), 
                    ("Возмущения", "Дополнительные", false) 
                },
                { 
                    typeof(Conditions), 
                    ("Переменные", "Дополнительные", false) 
                },
                { 
                    typeof(AOPO), 
                    ("АОПО", "Автоматика", false) 
                },
                { 
                    typeof(APNU), 
                    ("АПНУ", "Автоматика", false) 
                },
                { 
                    typeof(ARPM), 
                    ("АРПМ", "Автоматика", false) 
                },
                { 
                    typeof(AOSN), 
                    ("АОСН", "Автоматика", false) 
                },
                { 
                    typeof(Management), 
                    ("Руководство", "Администрирование", false) 
                },
                { 
                    typeof(ManagementTasks), 
                    ("Задачи", "Администрирование", true) 
                }
            };

        public EntityDefinition[] Map { get; }

        public EntityMap()
        {
            Map = GetReferenceMap();
        }

        private EntityDefinition[] GetReferenceMap() => 
            GetAssemblyType<ReferenceDataEntityAttribute>()
                .Select(t =>
                {
                    var (caption, category, readOnly) = _map
                        .TryGetValue(t, out var info)
                            ? info
                            : (t.Name, "Прочее", true);

                    return new EntityDefinition
                    {
                        EntityType = t,
                        Caption = caption,
                        Category = category,
                        IsReadOnly = readOnly
                    };
                }
            )
            .OrderBy(t => t.Category)
            .ThenBy(t => t.Caption)
            .ToArray();
    }
}
