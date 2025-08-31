using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApfBuilder.PowerFlow
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PowerFlowKind
    {
        PowerFlowStandard,
        PowerFlowSafe,
        PowerFlowForcedState,
        PowerFlowEmergency
    }
}
