using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pustok.DAL.DataContexts;

namespace Pustok.DAL
{
    public static class DataAccessLayerServicesRegistration
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default"),
            builder =>
            {
                builder.MigrationsAssembly("Pustok.DAL");
            }));
            return services;
        }
    }
}
