using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities.EntityRelations
{
    public enum RelationKind
    {
        OneToMany,
        ManyToOne,
        ManyToMany,
        OneToOne
    }
}
