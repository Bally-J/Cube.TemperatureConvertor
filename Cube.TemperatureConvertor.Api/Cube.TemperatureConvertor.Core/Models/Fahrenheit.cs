using Cube.Core.Validation;

namespace Cube.Core.Models
{
    public record struct Fahrenheit : ITemperature
    {
        private const double MaxTemp = 1.8e+32;
        private const double MinTemp = -459.67;
        private const string Postfix = "°F";
        public double Value { get; private set; }

        private Fahrenheit(double value)
        {
            Value = value;
        }

        public static Fahrenheit From(double value)
        {
            value.CheckIsInRange(MaxTemp, MinTemp, Postfix);

            return new Fahrenheit(value);
        }

        public override string ToString() => $"{Value}{Postfix}";
    }
}
