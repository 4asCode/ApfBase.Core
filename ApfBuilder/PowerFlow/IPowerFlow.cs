using ApfBuilder.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApfBuilder.Criteria.Core.Interfaces;
using System.Threading.Tasks;

namespace ApfBuilder.PowerFlow
{
    public interface IPowerFlow
    {
        ICriterion[] Criteria { get; }

        string Value { get; }

        string Description { get; }
    }
}
