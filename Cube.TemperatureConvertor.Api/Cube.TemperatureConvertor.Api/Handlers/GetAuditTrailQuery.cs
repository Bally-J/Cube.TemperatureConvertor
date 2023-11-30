using Cube.TemperatureConvertor.Api.Models;
using MediatR;

namespace Cube.TemperatureConvertor.Api.Handlers
{
    public class GetAuditTrailQuery : IRequest<AuditTrailResponse>
    {
        //Probably have to refine the logs with filter options
    }
}
