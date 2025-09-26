using ApfBuilder.Criteria.Core;
using DataBaseModels.ApfBaseEntities;
using Extensions;
using System.Collections.Generic;

namespace ApfBuilder.Services
{
    public class EmergencyResponseHandler
    {
        private EmergencyResponseHandler() { }

        public static IEnumerable<IEmergencyResponse> ProcessHandler(
            int? roundParam, CriterionType type, 
            params IEmergencyResponse[] emergencies)
        {
            foreach (var emergency in emergencies)
            {
                switch (emergency)
                {
                    case AOPO aopo:
                        aopo.Value = GetValueOrDescription(roundParam,
                            aopo.Coefficient, aopo.ControlValuePowerFlow
                            );
                        aopo.Description = GetValueOrDescription(roundParam,
                            aopo.Coefficient, aopo.FormalName
                            );
                        aopo.MaxValue = aopo.Value;
                        yield return aopo;
                        break;
                    case ARPM arpm:
                        arpm.Value = GetValueOrDescription(roundParam,
                            arpm.Coefficient, arpm.ControlValuePowerFlow
                            );
                        arpm.Description = GetValueOrDescription(roundParam,
                            arpm.Coefficient, arpm.FormalName
                            );
                        arpm.MaxValue = arpm.Value;
                        yield return arpm;
                        break;
                    case AOSN aosn:
                        aosn.Value = GetValueOrDescription(roundParam,
                            aosn.Coefficient, aosn.ControlValuePowerFlow
                            );
                        aosn.Description = GetValueOrDescription(roundParam,
                            aosn.Coefficient, aosn.FormalName
                            );
                        aosn.MaxValue = aosn.Value;
                        yield return aosn;
                        break;
                    case APNU apnu:
                        if (type == CriterionType.Static)
                        {
                            apnu.Value = GetValueOrDescription(roundParam,
                                apnu.StaticsCoefficient, 
                                apnu.ControlValuePowerFlow
                                );
                            apnu.MaxValue = apnu.Value;
                        }
                        if (type == CriterionType.Dynamic)
                        {
                            apnu.Value = GetValueOrDescription(roundParam,
                                apnu.DynamicsCoefficient, 
                                apnu.ControlValuePowerFlow
                                );
                            apnu.MaxValue = apnu.Value;
                        }
                        if (type == CriterionType.Current || 
                            type == CriterionType.CurrentAOPO
                            )
                        {
                            apnu.Value = GetValueOrDescription(roundParam,
                                apnu.CurrentCoefficient, 
                                apnu.ControlValuePowerFlow
                                );
                            apnu.MaxValue = apnu.Value;
                        }

                        apnu.Description = GetValueOrDescription(roundParam,
                                apnu.StaticsCoefficient, 
                                apnu.FormalName
                                );

                        yield return apnu;
                        break;
                    default: break;
                }
            }
        }

        private static dynamic GetValueOrDescription<TValue>(
            int? roundParam, double? coefficient, TValue value)
        {
            switch (value)
            {
                case string _:
                    if (coefficient != 1)
                        return $"{coefficient}*Δ{value}";
                    else
                        return $"Δ{value}";
                case double _:
                    double? roundValue = (coefficient * (
                        value as double?)
                        ).Round(roundParam);
                    return roundValue;
                default: return null;
            }
        }
    }
}
