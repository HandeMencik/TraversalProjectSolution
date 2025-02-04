using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TraversalReservationProject.Models;

var builder = WebApplication.CreateBuilder(args);

//  Serilog yapýlandýrmasý (Konsol + Dosya)
Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/app-log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
builder.Host.UseSerilog();

//  Gereksiz loglarý temizle
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

//  Microsoft ve System loglarýný engelle
builder.Logging.AddFilter("Microsoft.AspNetCore", LogLevel.None);
builder.Logging.AddFilter("System", LogLevel.None);
builder.Logging.SetMinimumLevel(LogLevel.Warning);

//  AddControllersWithViews() içinde `AuthorizeFilter` kullanýmý 
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    options.Filters.Add(new AuthorizeFilter(policy)); // Tüm sayfalara giriþ zorunluluðu ekler

    // 404 ve Hata Sayfalarýnda Yetkilendirmeyi Kaldýrýyoruz!
    options.Filters.Add(new IgnoreAntiforgeryTokenAttribute()); // CSRF hatasý almamak için
});

//  Yetkilendirme Middleware’ini sadece login gerektiren sayfalara uygula
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

//  Veritabaný baðlantýsýný yapýlandýralým
Console.WriteLine("Baðlantý Dizesi: " + builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<TraversalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Autofac Konteyneri Kullanýmý
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });

//  Identity Yapýlandýrmasý
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<TraversalContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

//  Hata Sayfasý ve HSTS Ayarý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//  404 sayfasýna yönlendirme yap, ama yetkilendirme gerektirme
app.UseStatusCodePagesWithRedirects("/hata/404/");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//  Rotalar
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

//  Static File Ayarlarý
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true
});

app.Run();
//using Autofac;
//using Autofac.Core;
//using Autofac.Extensions.DependencyInjection;
//using Business.Abstract;
//using Business.Concrete;
//using Business.DependencyResolvers.Autofac;
//using DataAccess.Abstract;
//using DataAccess.Concrete;
//using DataAccess.Context;
//using Entity.Concrete;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using Microsoft.EntityFrameworkCore;
//using Serilog;
//using TraversalReservationProject.Models;

//var builder = WebApplication.CreateBuilder(args);

//Log.Logger = new LoggerConfiguration()
//            .WriteTo.Console()
//            .WriteTo.File("logs/app-log-.txt", rollingInterval: RollingInterval.Day)
//            .CreateLogger();

//builder.Host.UseSerilog();

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//builder.Configuration
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//Console.WriteLine("Baðlantý Dizesi: " + builder.Configuration.GetConnectionString("DefaultConnection"));

//builder.Services.AddDbContext<TraversalContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
////.Net Core yerine baska bir IoC container kullanmak istersem ---> 
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
//            .ConfigureContainer<ContainerBuilder>(builder =>
//            {
//                builder.RegisterModule(new AutofacBusinessModule());
//            });




//builder.Services.AddIdentity<AppUser, AppRole>()
//    .AddEntityFrameworkStores<TraversalContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddControllersWithViews(options =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();

//    options.Filters.Add(new AuthorizeFilter(policy)); // Tüm sayfalara giriþ zorunluluðu getir
//});

//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization();

////  Varsayýlan loglarý temizleyelim (gereksiz loglarý önler)
//builder.Logging.ClearProviders();

//// Serilog ve Console loglarýný ekleyelim
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();

////  Minimum log seviyesini ayarla (sadece belirli seviyeleri göster)
//builder.Logging.SetMinimumLevel(LogLevel.Warning);
//var loggerFactory = LoggerFactory.Create(builder =>
//{
//    builder.ClearProviders(); // Tekrar temizleme yapalým
//    builder.AddConsole(); // Sadece Console loglarýný ekleyelim
//});

//var logger = loggerFactory.CreateLogger<Program>();
//logger.LogWarning("ClearProviders() çalýþýyor mu? Eðer sadece bu log görünüyorsa, baþarýlý!");


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
//app.UseStatusCodePagesWithRedirects("/hata/404/");
//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");


//app.MapControllerRoute(
//  name: "areas",
//  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//);
//app.MapControllerRoute(
//  name: "areas",
//  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//);
//app.UseStaticFiles(new StaticFileOptions
//{
//    ServeUnknownFileTypes = true
//});
//app.Run();
