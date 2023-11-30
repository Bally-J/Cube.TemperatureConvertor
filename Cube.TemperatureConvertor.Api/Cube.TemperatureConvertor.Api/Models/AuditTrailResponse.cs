using Cube.Core.Models;

namespace Cube.TemperatureConvertor.Api.Models
{
    public record AuditTrailResponse(List<AuditLog> AuditLogs);
}
