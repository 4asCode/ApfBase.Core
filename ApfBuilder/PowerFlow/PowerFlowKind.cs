using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ApfBuilder.PowerFlow
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PowerFlowKind
    {
        [EnumMember(Value = "PowerFlowStandard")]
        PowerFlowStandard,

        [EnumMember(Value = "PowerFlowSafe")]
        PowerFlowSafe,

        [EnumMember(Value = "PowerFlowForcedState")]
        PowerFlowForcedState,

        [EnumMember(Value = "PowerFlowEmergency")]
        PowerFlowEmergency
    }
}
