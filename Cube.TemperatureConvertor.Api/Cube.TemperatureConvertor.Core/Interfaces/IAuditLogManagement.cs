using Cube.Core.Models;

namespace Cube.Core.Interfaces
{
    public interface IAuditLogManagement
    {
        Task<bool> AuditUserAsync(ApiUser apiUser, string data);
        Task<List<AuditLog>> GetAllAuditLogs();
    }
}