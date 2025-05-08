var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.Use(async (context, next) =>
{
    var endpoint = context.GetEndpoint();
    var endpoint2 = context.User;
    var rulesEndpoint = (endpoint as RouteEndpoint)?.RoutePattern.RawText;
    Console.WriteLine($"{rulesEndpoint}");
    Console.WriteLine($"{endpoint}");
    Console.WriteLine($"{endpoint2} hello");
    await next(); 
});


app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id:int?}")
    .WithStaticAssets();


app.Run();