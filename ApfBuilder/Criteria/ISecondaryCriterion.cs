﻿using DataBaseModels.ApfBaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApfBuilder.Criteria
{
    public interface ISecondaryCriterion : ICriterion
    {
        string Postfix { get; }
    }
}
