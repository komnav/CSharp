using Microsoft.OpenApi.Models;
using RestaurantWeb.Extensions;
using RestaurantWeb.Repopsitories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITableRepository,TableRepository>();

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(
    c => c.SwaggerDoc(
        "v1", new OpenApiInfo
        {
            Title = "Restaurant application APIs", Version = "v1"
        })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant application APIs v1"); });
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapServerAPIs();

app.MapControllers();

app.UseWelcomePage();

app.Run();