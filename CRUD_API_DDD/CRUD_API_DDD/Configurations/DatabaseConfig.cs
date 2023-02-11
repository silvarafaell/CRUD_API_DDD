using CRUD.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FactoryContext>(options =>
                        options.UseSqlServer(GetApiConnectionString(configuration))
                        .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information));
        }

        public static string GetApiConnectionString(IConfiguration configuration)
            => configuration.GetConnectionString("Empregado");
    }
}
