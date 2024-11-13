using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pustok.BLL.Services.Contracts;
using Pustok.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.BLL
{
    public static class BusinessLogicLayerServicesRegistration
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(ICrudService<,,,>), typeof(CrudManager<,,,>));
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductImageService, ProductImageManager>();
            services.AddScoped<ISettingService, SettingManager>();
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<ISubscribeService, SubscribeManager>();
            services.AddScoped<ITagService, TagManager>();
            services.AddScoped<IBasketItemService, BasketItemManager>();
            services.AddScoped<IHomeService, HomeManager>();
            services.AddScoped<CloudinaryManager>();
            services.AddScoped<IAccountService, AccountManager>();



            return services;
        }
    }
}
