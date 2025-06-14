using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModels.ApfBaseEntities
{
    public interface IEmergencyResponse 
    {
        double? Value { get; set; }

        string Description { get; set; }

        double? MinValue { get; set; }

        double? MaxValue { get; set; }
    }
}
