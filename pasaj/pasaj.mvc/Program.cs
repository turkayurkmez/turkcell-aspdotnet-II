using pasaj.DataAccess.Repositories;
using pasaj.Service;
using pasaj.Service.MappingProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, FakeProductRepository>();
builder.Services.AddScoped<ICategoryRepository, FakeCategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddAutoMapper(typeof(MapProfile));

/*
 *  1. Singleton: Tekil nesne, sadece bir kez constructor çalışsın (bir kere instance alınsın) ve uygulama çalıştığı sürece dispose olmasın.
 *  
 *  2. Transient: Her seferinde (ihtiyaç) yeni bir instance istiyorsanız transient kullanılır.
 *  3. Scoped: Her httpRequest'de yeni bir instance al ama bu instance'i ihtiyaç duyulan her yerde kullan.
 *  
 */

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseAuthorization();


app.MapControllerRoute(
    name: "paging",
    pattern: "Page{page}",
    defaults: new { controller = "Home", action = "Index", page = 1 });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
