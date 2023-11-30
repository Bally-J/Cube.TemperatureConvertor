using Cube.Core.Interfaces;
using Cube.Core.Models;
using Cube.Data;
using Cube.TemperatureConvertor.ConversionService;

namespace Cube.Services.TemperatureConversionService
{
    public class TemperatureConversionManagement : ITemperatureConversionManagement
    {
        private readonly IAuditLogManagement _AuditLog;

        public ApiUser? User { get; set; }

        public TemperatureConversionManagement(IAuditLogManagement auditLog)
        {
            _AuditLog = auditLog;
        }

        public async Task<Celsius> ConvertToCelsiusAsync(Kelvin temperature)
        {
            var value = ConversionLogic.ConvertKelvinToCelsius(temperature.Value);
            var result = Celsius.From(value);
            
            await AuditLogUserAsync(temperature, result);

            return result;
        }

        public async Task<Celsius> ConvertToCelsiusAsync(Fahrenheit temperature)
        {
            var value = ConversionLogic.ConvertFahrenheitToCelsius(temperature.Value);
            var result = Celsius.From(value);
            
            await AuditLogUserAsync(temperature, result);

            return result;
        }

        public async Task<Kelvin> ConvertToKelvinAsync(Celsius temperature)
        {
            var value = ConversionLogic.ConvertCelsiusToKelvin(temperature.Value);
            var result = Kelvin.From(value);
            
            await AuditLogUserAsync(temperature, result);

            return result;
        }

        public async Task<Kelvin> ConvertToKelvinAsync(Fahrenheit temperature)
        {
            var value = ConversionLogic.ConvertFahrenheitToKelvin(temperature.Value);
            var result = Kelvin.From(value);
            
            await AuditLogUserAsync(temperature, result);

            return result;
        }


        public async Task<Fahrenheit> ConvertToFahrenheitAsync(Celsius temperature)
        {
            var value = ConversionLogic.ConvertCelsiusToFahrenheit(temperature.Value);
            var result = Fahrenheit.From(value);
            
            await AuditLogUserAsync(temperature, result);

            return result;
        }

        public async Task<Fahrenheit> ConvertToFahrenheitAsync(Kelvin temperature)
        {
            var value = ConversionLogic.ConvertKelvinToFahrenheit(temperature.Value);
            var result = Fahrenheit.From(value);

            await AuditLogUserAsync(temperature, result);

            return result;
        }

        protected async Task AuditLogUserAsync(ITemperature fromTemp, ITemperature toTemp)
        {
            if (User is null)
                return;

            await _AuditLog.AuditUserAsync(User, $"Converted {fromTemp.ToString()} to {toTemp.ToString()}");
        }
    }
}
