using Cube.Core.Enums;

namespace Cube.Core.Exceptions
{
    public class OutOfTemperatureRangeException : UserException
    {
        public double TemperatureValue { get; }
        public double MaxTemperatureValue { get; }
        public double MinTemperatureValue { get; }
        public string TemperatureUnitPostfix { get; }
        
        public OutOfTemperatureRangeException(double temperatureValue, double maxTemperatureValue, double minTemperatureValue, string temperatureUnitPostfix)
        {
            TemperatureValue = temperatureValue;
            MaxTemperatureValue = maxTemperatureValue;
            MinTemperatureValue = minTemperatureValue;
            TemperatureUnitPostfix = temperatureUnitPostfix;
        }

        public override string Message => $"Temperature Value '{TemperatureValue}' Is Out Of Range. Temperature Value Must Between {MinTemperatureValue}{TemperatureUnitPostfix} And {MaxTemperatureValue}{TemperatureUnitPostfix}";
    }
}
