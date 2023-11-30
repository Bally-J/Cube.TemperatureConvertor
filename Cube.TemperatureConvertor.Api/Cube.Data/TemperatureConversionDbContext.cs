using Cube.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cube.Data
{
    public class TemperatureConversionDbContext : DbContext, ITemperatureConversionDbContext
    {
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public TemperatureConversionDbContext(DbContextOptions<TemperatureConversionDbContext> options) : base(options) { }
    }
}