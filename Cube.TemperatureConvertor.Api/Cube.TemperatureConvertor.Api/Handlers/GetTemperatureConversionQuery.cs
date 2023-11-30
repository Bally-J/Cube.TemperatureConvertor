using Cube.TemperatureConvertor.Api.Models;
using MediatR;

namespace Cube.TemperatureConvertor.Api.Handlers
{
    public class GetTemperatureConversionQuery : IRequest<TemperatureConversionResponse>
    {
        public TemperatureConversionRequest RequestDetails { get; }
        public GetTemperatureConversionQuery(TemperatureConversionRequest request)
        {
            RequestDetails = request;
        }
    }
}
