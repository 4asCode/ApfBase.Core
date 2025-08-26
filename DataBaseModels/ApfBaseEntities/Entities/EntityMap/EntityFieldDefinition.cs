using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities.Entities.EntityMap
{
    public class EntityFieldDefinition : IDefinition
    {
        public Type EntityType { get; set; }

        public IReadOnlyList<FieldDefinition> Fields { get; set; }

        public class FieldDefinition : IComparable<FieldDefinition>
        {
            public string Name { get; set; }

            public string FieldName { get; set; }

            public Type DataType { get; set; }

            public int Index { get; set; }

            public bool Visible { get; set; }

            public bool IsReadOnly { get; set; }

            public int CompareTo(FieldDefinition field)
            {
                if (ReferenceEquals(field, null)) return 1;

                return Index < field.Index ? -1 
                    : (Index > field.Index ? 1 : 0);
            }
        }
    }
}
