using Cube.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube.Core.Exceptions
{
    public class ConversionNotSupportedException : UserException
    {
        public TemperatureUnit ConvertedFrom { get; }
        public TemperatureUnit ConvertedTo { get; }

        public ConversionNotSupportedException(TemperatureUnit convertedFrom, TemperatureUnit convertedTo) { 
            ConvertedFrom = convertedFrom;
            ConvertedTo = convertedTo;
        }

        public override string Message => $"Conversion From {ConvertedFrom} To {ConvertedTo} Is Not Supported";
    }
}
