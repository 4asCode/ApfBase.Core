using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities.Entities.EntityMap
{
    public interface IDefinition
    {
        Type EntityType { get; set; }
    }
}
