using BLL.Implementation;
using BLL.Services;
using BLL.Services.IServices;
using DAL.Repository.IRepository;
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
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();

            return services;
        }
    }
}
