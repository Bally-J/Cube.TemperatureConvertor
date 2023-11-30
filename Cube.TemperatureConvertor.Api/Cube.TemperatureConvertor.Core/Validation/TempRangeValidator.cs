using Cube.Core.Exceptions;

namespace Cube.Core.Validation
{
    public static class TempRangeValidator
    {
        public static void CheckIsInRange(this double value, double max, double min, string postfix)
        {
            if (value > max || value < min)
                throw new OutOfTemperatureRangeException(value, max, min, postfix);
        }
    }
}
