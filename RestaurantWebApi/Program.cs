using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RestaurantWeb.Extensions;
using RestaurantWeb.Infrastructure.DataBase;
using RestaurantWeb.Middlewares;
using RestaurantWeb.Model;
using RestaurantWeb.Model.Enums;
using RestaurantWeb.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.JwtAuthServiceExtensions();
builder.Services.AddAuthorization();
//builder.SendLog();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddOpenApi();
builder.AddExtensions();
builder.Services.AddMemoryCache();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<TableDtoValidator>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RestaurantContext>();
    dbContext.Database.Migrate();
    if (!dbContext.Users.Any())
    {
        var user = new User
        {
            UserName = "superAdmin",
            Password = "12345678",
            Role = UserRoles.SuperAdmin
        };

        dbContext.Users.Add(user);
        dbContext.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapServerApIs();
app.MapControllers();
app.Run();

public partial class Program
{
}