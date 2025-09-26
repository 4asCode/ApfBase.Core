using System.Collections.Generic;

namespace ApfBuilder.PowerFlow.Factory
{
    public interface IPowerFlowCollectionFactory
    {
        IEnumerable<IPowerFlowFactory> PowerFlowFactories { get; }
    }
}
