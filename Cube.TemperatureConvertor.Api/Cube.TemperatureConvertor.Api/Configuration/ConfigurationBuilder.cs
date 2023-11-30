using Cube.Core.Interfaces;
using Cube.Data;
using Cube.Services.AuditLogService;
using Cube.Services.TemperatureConversionService;

namespace Cube.TemperatureConvertor.Api.Configuration
{
    public static class ConfigurationBuilder
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ITemperatureConversionDbContext, TemperatureConversionDbContext>();
            services.AddScoped<ITemperatureConversionManagement, TemperatureConversionManagement>();
            services.AddScoped<IAuditLogManagement, AuditLogManagement>();
        }
    }
}
