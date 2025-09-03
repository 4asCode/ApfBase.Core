using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ApfBuilder.Criteria.Core
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CriterionType
    {
        [EnumMember(Value = "Current")]
        Current,

        [EnumMember(Value = "Dynamic")]
        Dynamic,

        [EnumMember(Value = "Static")]
        Static,

        [EnumMember(Value = "Voltage")]
        Voltage,

        [EnumMember(Value = "Frequency")]
        Frequency,

        [EnumMember(Value = "FrequencyAlternate")]
        FrequencyAlternate,

        [EnumMember(Value = "CurrentAOPO")]
        CurrentAOPO,

        [EnumMember(Value = "CurrentSecondary")]
        CurrentSecondary,

        [EnumMember(Value = "VoltageSecondary")]
        VoltageSecondary,

        [EnumMember(Value = "StaticBaseCaseTPR")]
        StaticBaseCaseTPR,

        [EnumMember(Value = "StaticBaseCaseEPR")]
        StaticBaseCaseEPR
    }
}
