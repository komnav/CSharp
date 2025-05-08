using Losson9;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var settings = new HostApplicationBuilderSettings
{
    ContentRootPath = Directory.GetCurrentDirectory(),
};
var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<HostOptions>(o => 
    o.ServicesStartConcurrently=true
);
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddHostedService<ExampleHostedService>();

var host = builder.Build();

var lifeTime = host.Services.GetRequiredService<IHostApplicationLifetime>();
lifeTime.ApplicationStarted.Register(() => Console.WriteLine("Application started"));
lifeTime.ApplicationStopped.Register(() => Console.WriteLine("Application stopped")); 

host.Run();