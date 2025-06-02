using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Exceptions;
using RestaurantWeb.Extensions;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Validations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

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