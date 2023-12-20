using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Services;
using Restaurant.Domain.Interfaces.Repositories;
using Restaurant.Infra.Data.Contexts;
using Restaurant.Infra.Data.Repositories;

namespace Restaurant.Infra.IoC;

public static class RegisterDependencies
{
    public static void InsertDependencies(this IServiceCollection  services, IConfiguration configuration)
    {
        RegisterContext(services, configuration);
        RegisterRepositories(services);
        RegisterServices(services);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        //services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
        services.AddScoped<IDishService, DishService>();
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        //services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
        services.AddScoped<IDishRepository, DishRepository>();
    }

    private static void RegisterContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RestaurantContext>(options => 
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
    }
}
