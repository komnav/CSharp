using FluentValidation;
using Microsoft.OpenApi.Models;
using RestaurantWeb.Extensions;
using RestaurantWeb.Mappers;
using RestaurantWeb.Middlewares;
using RestaurantWeb.Repositories;
using RestaurantWeb.Services;
using RestaurantWeb.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddSingleton<ITableRepository, TableRepository>();
builder.Services.AddSingleton<IReservationRepository, ReservationRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddSingleton<IMenuCategoryRepository, MenuCategoryRepository>();
builder.Services.AddSingleton<IContactRepository, ContactRepository>();

builder.Services.AddScoped<ITableService, TableService>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(
    c => c.SwaggerDoc(
        "v1", new OpenApiInfo
        {
            Title = "Restaurant application APIs", Version = "v1"
        })
);
builder.Services.AddAutoMapper(opt
    =>
{
    opt.AddMaps(typeof(TableProfile).Assembly);
});

builder.Services.AddValidatorsFromAssemblyContaining<TableDtoValidator>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();
app.MapServerAPIs();

app.MapControllers();

app.Run();