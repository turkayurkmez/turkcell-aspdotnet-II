var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


var app = builder.Build();



var value = app.Configuration.GetSection("Custom")["value"];
app.Logger.LogInformation($"Ortam değerinden gelen veri: {value}");

//app.UseWelcomePage()
app.UseStaticFiles();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


app.Run();
