using ApfBuilder.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApfBuilder.PowerFlow.Factory
{
    public interface IPowerFlowFactory
    {
        IPowerFlow PowerFlow { get; }
    }
}
