using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Extensions;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Infrastructure.Interceptors;
using RestaurantWeb.Validations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<AvoidDeletingContactInterceptor>();

builder.Services.AddDbContext<RestaurantContext>((cp, options) =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .AddInterceptors(cp.GetRequiredService<AvoidDeletingContactInterceptor>());
});

builder.AddRepositoryLayer();
builder.Services.AddMemoryCache();
builder.AddServiceLayer();
builder.AddRedisServiceLayer();

builder.Services.AddSwaggerGen();
builder.AddAutoMapperLayer();

builder.Services.AddValidatorsFromAssemblyContaining<TableDtoValidator>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RestaurantContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapServerApIs();
app.MapControllers();
app.Run();