using Cube.Core.Interfaces;
using Cube.TemperatureConvertor.Api.Models;
using MediatR;

namespace Cube.TemperatureConvertor.Api.Handlers
{
    public class GetAuditTrailQueryHandler : IRequestHandler<GetAuditTrailQuery, AuditTrailResponse>
    {
        private readonly IAuditLogManagement _AuditLogManagement;

        public GetAuditTrailQueryHandler(IAuditLogManagement auditLogManagement)
        {
            _AuditLogManagement = auditLogManagement;
        }

        public async Task<AuditTrailResponse> Handle(GetAuditTrailQuery request, CancellationToken cancellationToken) => 
            new AuditTrailResponse(await _AuditLogManagement
                .GetAllAuditLogs());
    }
}
