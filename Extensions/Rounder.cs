using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class Rounder
    {
        public static int Value { get; private set; } = 1;

        public static void SetValue(int value)
        {
            if (value == 0)
            {
                throw new ArgumentException(
                    "Вероятность получения " +
                    "\"Not-a-Number\". " +
                    "Значение \"0\" не допускается!"
                    );
            }

            Value = value;
        }

        public static double? Round(this double? value) =>
            value == null ? null : (double?)Math.Floor(
                Convert.ToDouble(value - value % Value)
                );
    }
}
