﻿using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApfBuilder.Criteria
{
    public interface IEmergencyResponceCriterion : ICriterion 
    {
        IEnumerable<IEmergencyResponse> EmergencyResponse { get; }

        Conditions Condition { get; }

        Disturbances Disturbance { get; }

        double? MinValueER { get; }

        double? MaxValueER { get; }
    }
}
