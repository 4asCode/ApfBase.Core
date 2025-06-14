using ApfBuilder.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
