using RestaurantWeb.Mappers;
using RestaurantWeb.Repositories;
using RestaurantWeb.Services;

namespace RestaurantWeb.Extensions;

public static class ServiceExtensions
{
    public static void AddRepositoryLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITableRepository, TableRepository>();
        builder.Services.AddScoped<ReservationRepository>();
        builder.Services.AddScoped<IReservationRepository, CachedMemberRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        builder.Services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();
        builder.Services.AddScoped<IContactRepository, ContactRepository>();
    }

    public static void AddServiceLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITableService, TableService>();
        builder.Services.AddScoped<IReservationService, ReservationService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IMenuItemService, MenuItemService>();
        builder.Services.AddScoped<IMenuCategoryService, MenuCategoryService>();
        builder.Services.AddScoped<IContactService, ContactService>();
    }

    public static void AddRedisServiceLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddStackExchangeRedisCache(redisOptions =>
        {
            string connection = builder.Configuration
                .GetConnectionString("Redis");
            redisOptions.Configuration = connection;
        });
    }

    public static void AddAutoMapperLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(opt
            =>
        {
            opt.AddMaps(typeof(TableProfile).Assembly);
        });
    }
}