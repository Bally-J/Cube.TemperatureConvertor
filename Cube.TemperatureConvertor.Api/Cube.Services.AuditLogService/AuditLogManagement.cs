using Cube.Core.Interfaces;
using Cube.Core.Models;
using Cube.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Cube.Services.AuditLogService
{
    public class AuditLogManagement : IAuditLogManagement
    {
        private readonly ITemperatureConversionDbContext _TemperatureConversionDbContext;


        public AuditLogManagement(ITemperatureConversionDbContext temperatureConversionDbContext)
        {
            _TemperatureConversionDbContext = temperatureConversionDbContext;
        }

        public async Task<bool> AuditUserAsync(ApiUser apiUser, string data)
        {
            try 
            {
                await _TemperatureConversionDbContext.AuditTrails.AddAsync(new Data.Entities.AuditTrail()
                {
                    Id = Guid.NewGuid(),
                    Data = data,
                    RecordedDateUTC = DateTime.Now.ToUniversalTime(),
                    UserName = apiUser.Username
                });

                return await _TemperatureConversionDbContext.SaveChangesAsync() > 0;
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Failed to add data to Audit log: \n\r {data}", ex);
            }
        }

        public async Task<List<AuditLog>> GetAllAuditLogs() =>
            await _TemperatureConversionDbContext
                    .AuditTrails
                    .AsNoTracking()
                    .Select(x => new AuditLog()
                    {
                        UserName = x.UserName,
                        Data = x.Data,
                        RecordedDateUTC = x.RecordedDateUTC,
                    }).ToListAsync();
    }
}