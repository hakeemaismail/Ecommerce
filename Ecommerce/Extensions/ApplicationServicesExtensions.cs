using BLL.Implementation;
using BLL.Services;
using DAL.Repository;
using Ecommerce.Repositories;

namespace Ecommerce.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
