using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApfBuilder.Criteria.Core;
using DataBaseModels.ApfBaseEntities;
using static ApfBuilder.Criteria.CriterionAttribute;
using Extensions;

namespace ApfBuilder.Services
{
    public class EmergencyResponseHandler
    {
        private EmergencyResponseHandler() { }

        public static IEnumerable<IEmergencyResponse> ProcessHandler(
            CriterionType type, params IEmergencyResponse[] emergencies)
        {
            foreach (var emergency in emergencies)
            {
                switch (emergency)
                {
                    case AOPO aopo:
                        aopo.Value = GetValueOrDescription(
                            aopo.Coefficient, aopo.ControlValuePowerFlow
                            );
                        aopo.Description = GetValueOrDescription(
                            aopo.Coefficient, aopo.FormalName
                            );
                        aopo.MaxValue = aopo.Value;
                        yield return aopo;
                        break;
                    case ARPM arpm:
                        arpm.Value = GetValueOrDescription(
                            arpm.Coefficient, arpm.ControlValuePowerFlow
                            );
                        arpm.Description = GetValueOrDescription(
                            arpm.Coefficient, arpm.FormalName
                            );
                        arpm.MaxValue = arpm.Value;
                        yield return arpm;
                        break;
                    case AOSN aosn:
                        aosn.Value = GetValueOrDescription(
                            aosn.Coefficient, aosn.ControlValuePowerFlow
                            );
                        aosn.Description = GetValueOrDescription(
                            aosn.Coefficient, aosn.FormalName
                            );
                        aosn.MaxValue = aosn.Value;
                        yield return aosn;
                        break;
                    case APNU apnu:
                        if (type == CriterionType.Static)
                        {
                            apnu.Value = GetValueOrDescription(
                                apnu.StaticsCoefficient, apnu.ControlValuePowerFlow
                                );
                            apnu.MaxValue = apnu.Value;
                        }
                        if (type == CriterionType.Dynamic)
                        {
                            apnu.Value = GetValueOrDescription(
                                apnu.DynamicsCoefficient, apnu.ControlValuePowerFlow
                                );
                            apnu.MaxValue = apnu.Value;
                        }
                        if (type == CriterionType.Current || 
                            type == CriterionType.CurrentAOPO
                            )
                        {
                            apnu.Value = GetValueOrDescription(
                                apnu.CurrentCoefficient, apnu.ControlValuePowerFlow
                                );
                            apnu.MaxValue = apnu.Value;
                        }

                        apnu.Description = GetValueOrDescription(
                                apnu.StaticsCoefficient, apnu.FormalName
                                );

                        yield return apnu;
                        break;
                    default: break;
                }
            }
        }

        private static dynamic GetValueOrDescription<TValue>(
            double? coefficient, TValue value)
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
                        ).Round();
                    return roundValue;
                default: return null;
            }
        }
    }
}
