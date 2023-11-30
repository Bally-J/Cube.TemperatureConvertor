using Cube.Core.Validation;

namespace Cube.Core.Models
{
    public record struct Celsius : ITemperature
    {
        private const double MaxTemp = 1e+32;
        private const double MinTemp = -273.15;
        private const string Postfix = "°C";
        public double Value { get; private set; }

        private Celsius(double value)
        {
            Value = value;
        }

        public static Celsius From(double value)
        {
            value.CheckIsInRange(MaxTemp, MinTemp, Postfix);

            return new Celsius(value);
        }

        public override string ToString() => $"{Value}{Postfix}";
    }
}
