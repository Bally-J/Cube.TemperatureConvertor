using Cube.Core.Validation;

namespace Cube.Core.Models
{
    public record struct Kelvin : ITemperature
    {
        private const double MaxTemp = 1e+32;
        private const double MinTemp = 0;
        private const string Postfix = "K";
        public double Value { get; private set; }

        private Kelvin(double value)
        {
            Value = value;
        }

        public static Kelvin From(double value)
        {
            value.CheckIsInRange(MaxTemp, MinTemp, Postfix);
            
            return new Kelvin(value);
        }

        public override string ToString() => $"{Value}{Postfix}";
    }
}
