using Cube.Core.Models;

namespace Cube.Core.Interfaces
{
    public interface ITemperatureConversionManagement
    {
        ApiUser? User { get; set; }
        Task<Celsius> ConvertToCelsiusAsync(Fahrenheit temperature);
        Task<Celsius> ConvertToCelsiusAsync(Kelvin temperature);
        Task<Fahrenheit> ConvertToFahrenheitAsync(Celsius temperature);
        Task<Fahrenheit> ConvertToFahrenheitAsync(Kelvin temperature);
        Task<Kelvin> ConvertToKelvinAsync(Celsius temperature);
        Task<Kelvin> ConvertToKelvinAsync(Fahrenheit temperature);
    }
}