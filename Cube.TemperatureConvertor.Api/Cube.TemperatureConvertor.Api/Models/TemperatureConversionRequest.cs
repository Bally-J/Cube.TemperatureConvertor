using Cube.Core.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cube.TemperatureConvertor.Api.Models
{
    public class TemperatureConversionRequest
    {
        [Required]
        public double TemperatureToConvert { get; set; } 
        [Required]
        [EnumDataType(typeof(TemperatureUnit))]
        public TemperatureUnit ConvertFromTemperatureUnit { get; set; }
        [Required]
        [EnumDataType(typeof(TemperatureUnit))]
        public TemperatureUnit ConvertToTemperatureUnit { get; set; } 
        [Required]
        public string Username { get; set; }
    }
}
