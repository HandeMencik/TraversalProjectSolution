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

//  Serilog yap�land�rmas� (Konsol + Dosya)
Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/app-log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
builder.Host.UseSerilog();

//  Gereksiz loglar� temizle
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

//  Microsoft ve System loglar�n� engelle
builder.Logging.AddFilter("Microsoft.AspNetCore", LogLevel.None);
builder.Logging.AddFilter("System", LogLevel.None);
builder.Logging.SetMinimumLevel(LogLevel.Warning);

//  AddControllersWithViews() i�inde `AuthorizeFilter` kullan�m� 
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    options.Filters.Add(new AuthorizeFilter(policy)); // T�m sayfalara giri� zorunlulu�u ekler

    // 404 ve Hata Sayfalar�nda Yetkilendirmeyi Kald�r�yoruz!
    options.Filters.Add(new IgnoreAntiforgeryTokenAttribute()); // CSRF hatas� almamak i�in
});

//  Yetkilendirme Middleware�ini sadece login gerektiren sayfalara uygula
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

//  Veritaban� ba�lant�s�n� yap�land�ral�m
Console.WriteLine("Ba�lant� Dizesi: " + builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<TraversalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Autofac Konteyneri Kullan�m�
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });

//  Identity Yap�land�rmas�
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<TraversalContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

//  Hata Sayfas� ve HSTS Ayar�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//  404 sayfas�na y�nlendirme yap, ama yetkilendirme gerektirme
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

//  Static File Ayarlar�
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

//Console.WriteLine("Ba�lant� Dizesi: " + builder.Configuration.GetConnectionString("DefaultConnection"));

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

//    options.Filters.Add(new AuthorizeFilter(policy)); // T�m sayfalara giri� zorunlulu�u getir
//});

//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization();

////  Varsay�lan loglar� temizleyelim (gereksiz loglar� �nler)
//builder.Logging.ClearProviders();

//// Serilog ve Console loglar�n� ekleyelim
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();

////  Minimum log seviyesini ayarla (sadece belirli seviyeleri g�ster)
//builder.Logging.SetMinimumLevel(LogLevel.Warning);
//var loggerFactory = LoggerFactory.Create(builder =>
//{
//    builder.ClearProviders(); // Tekrar temizleme yapal�m
//    builder.AddConsole(); // Sadece Console loglar�n� ekleyelim
//});

//var logger = loggerFactory.CreateLogger<Program>();
//logger.LogWarning("ClearProviders() �al���yor mu? E�er sadece bu log g�r�n�yorsa, ba�ar�l�!");


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
