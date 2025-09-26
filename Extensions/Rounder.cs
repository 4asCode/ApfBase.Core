using System;

namespace Extensions
{
    public static class Rounder
    {
        private static readonly int _defaultRoundValue = 1;

        public static double? Round(this double? value, int? roundParam) =>
            value == null ? null : (double?)Math.Floor(
                value.Value - value.Value % 
                    (
                        (roundParam == null || roundParam <= 0) 
                            ? _defaultRoundValue
                            : roundParam.Value
                    )
                );
    }
}
