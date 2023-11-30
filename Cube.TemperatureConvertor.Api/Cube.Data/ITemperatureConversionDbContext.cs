using Cube.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cube.Data
{
    public interface ITemperatureConversionDbContext: IDisposable
    { 
        DbSet<AuditTrail> AuditTrails { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}