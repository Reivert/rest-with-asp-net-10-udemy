using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace RestWithASPNET10Erudio.Configurations
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveConfiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                var connectionString = configuration["MSSQLServerConnection:MSSQLServerConnectionString"];

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'MSSQLServer' is not found.");
                }

                try
                {
                    using var evolveConnection = new SqlConnection(connectionString);
                    var evolve = new Evolve(
                        evolveConnection,
                        msg => Log.Information(msg))
                    {
                        Locations = new List<string> { "db/migrations", "db/dataset" },
                        IsEraseDisabled = true,
                        CommandTimeout = 60
                    };
                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error ocurred while migrating the database!");
                }
            }

            return services;
        }
    }
}
