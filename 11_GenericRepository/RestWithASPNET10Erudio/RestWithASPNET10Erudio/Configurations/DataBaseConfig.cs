using Microsoft.EntityFrameworkCore;
using RestWithASPNET10Erudio.Model.Context;

namespace RestWithASPNET10Erudio.Configurations
{
    public static class DataBaseConfig
    {
        public static IServiceCollection AddDataBaseConfiguration(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MSSQLServerConnection:MSSQLServerConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'MSSQLServer' is not found.");
            }
                services.AddDbContext<MSSQLContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
