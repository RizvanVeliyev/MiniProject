using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pustok.DAL.DataContexts;
using Pustok.DAL.Repositories.Contracts;
using Pustok.DAL.Repositories;

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

            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ISubscribeRepository, SubscribeRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();


            return services;
        }
    }
}
