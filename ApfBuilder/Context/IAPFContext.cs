using ApfBuilder.PowerFlow;
using DataBaseModels.ApfBaseEntities;
using System.Threading.Tasks;

namespace ApfBuilder.Context
{
    public interface IAPFContext
    {
        PreFaultConditions PreF { get; }

        APF Apf { get; set; }

        IPowerFlow[] PowerFlows { get; set; }

        void ExecuteBuild();

        Task ExecuteBuildAsync();

        void APFHandler();

        void Save();
    }
}
