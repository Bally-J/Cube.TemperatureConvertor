using Cube.Core.Enums;
using Cube.Core.Exceptions;
using Cube.Core.Interfaces;
using Cube.Core.Models;
using Cube.TemperatureConvertor.Api.Models;
using MediatR;

namespace Cube.TemperatureConvertor.Api.Handlers
{
    public class GetTemperatureConversionQueryHandler : IRequestHandler<GetTemperatureConversionQuery, TemperatureConversionResponse>
    {
        private readonly ITemperatureConversionManagement _TemperatureConversionManagement;

        public GetTemperatureConversionQueryHandler(ITemperatureConversionManagement temperatureConversionManagement)
        {
            _TemperatureConversionManagement = temperatureConversionManagement;
        }

        public async Task<TemperatureConversionResponse> Handle(GetTemperatureConversionQuery request, CancellationToken cancellationToken)
        {
            _TemperatureConversionManagement.User = new ApiUser() { Username = request.RequestDetails.Username };

            string responseText = request.RequestDetails.ConvertFromTemperatureUnit switch
            {
                TemperatureUnit.Kelvin => request.RequestDetails.ConvertToTemperatureUnit switch
                {
                    TemperatureUnit.Celsius => (await _TemperatureConversionManagement.ConvertToCelsiusAsync(Kelvin.From(request.RequestDetails.TemperatureToConvert))).ToString(),
                    TemperatureUnit.Fahrenheit => (await _TemperatureConversionManagement.ConvertToFahrenheitAsync(Kelvin.From(request.RequestDetails.TemperatureToConvert))).ToString(),
                    _ => throw new ConversionNotSupportedException(request.RequestDetails.ConvertFromTemperatureUnit, request.RequestDetails.ConvertToTemperatureUnit)
                },
                TemperatureUnit.Fahrenheit => request.RequestDetails.ConvertToTemperatureUnit switch
                {
                    TemperatureUnit.Celsius => (await _TemperatureConversionManagement.ConvertToCelsiusAsync(Fahrenheit.From(request.RequestDetails.TemperatureToConvert))).ToString(),
                    TemperatureUnit.Kelvin => (await _TemperatureConversionManagement.ConvertToKelvinAsync(Fahrenheit.From(request.RequestDetails.TemperatureToConvert))).ToString(),
                    _ => throw new ConversionNotSupportedException(request.RequestDetails.ConvertFromTemperatureUnit, request.RequestDetails.ConvertToTemperatureUnit)
                },
                TemperatureUnit.Celsius => request.RequestDetails.ConvertToTemperatureUnit switch
                {
                    TemperatureUnit.Fahrenheit => (await _TemperatureConversionManagement.ConvertToFahrenheitAsync(Celsius.From(request.RequestDetails.TemperatureToConvert))).ToString(),
                    TemperatureUnit.Kelvin => (await _TemperatureConversionManagement.ConvertToKelvinAsync(Celsius.From(request.RequestDetails.TemperatureToConvert))).ToString(),
                    _ => throw new ConversionNotSupportedException(request.RequestDetails.ConvertFromTemperatureUnit, request.RequestDetails.ConvertToTemperatureUnit)
                },
                _ => throw new ConversionNotSupportedException(request.RequestDetails.ConvertFromTemperatureUnit, request.RequestDetails.ConvertToTemperatureUnit)
            };

            return new TemperatureConversionResponse(responseText);
        }
    }
}
