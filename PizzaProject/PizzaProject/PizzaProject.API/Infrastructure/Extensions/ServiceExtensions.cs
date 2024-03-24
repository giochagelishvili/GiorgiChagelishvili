using PizzaProject.Application.Addresses;
using PizzaProject.Application.Orders;
using PizzaProject.Application.Pizzas;
using PizzaProject.Application.RankHistories;
using PizzaProject.Application.Repositories;
using PizzaProject.Application.Users;
using PizzaProject.Infrastructure.Addresses;
using PizzaProject.Infrastructure.Orders;
using PizzaProject.Infrastructure.Pizzas;
using PizzaProject.Infrastructure.RankHistories;
using PizzaProject.Infrastructure.Users;

namespace PizzaProject.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRankHistoryService, RankHistoryService>();

            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRankHistoryRepository, RankHistoryRepository>();
        }
    }
}
