using System.Text.Json.Serialization;
using FluentValidation;
using RestaurantWeb.Extensions;
using RestaurantWeb.Loggers;
using RestaurantWeb.Middlewares;
using RestaurantWeb.Validations;

var builder = WebApplication.CreateBuilder(args);

builder.SendLog();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddOpenApi();

builder.AddExtensions();

builder.Services.AddMemoryCache();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<TableDtoValidator>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapServerApIs();
app.MapControllers();
app.Run();