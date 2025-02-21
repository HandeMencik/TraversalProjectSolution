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
using TraversalReservationProject.CQRS.Handlers.DestinationHandlers;
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
builder.Services.AddScoped<GetAllDestinationQueryHandler>();
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

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddHttpClient();   

var app = builder.Build();

//  Hata Sayfas� ve HSTS Ayar�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//  404 sayfas�na y�nlendirme yap, ama yetkilendirme gerektirme
//app.UseStatusCodePagesWithRedirects("/hata/404/");
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
