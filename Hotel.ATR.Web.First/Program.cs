using FluentValidation;
using Hotel.ATR.Web.First.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews(options =>
    {
        options.Filters.Add<CustomHeaderRecourceFilter>();
        options.Filters.Add<GlobalExceptionFilter>();
    })
    .AddViewLocalization();

builder.Services.AddScoped<IValidator<ContactForm>, ContactFormValidator>();

//настройка посредника для подключения к БазеДанных
string conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
options.UseSqlServer(conn));


string conn2 = builder.Configuration.GetConnectionString("BaseConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(conn2));


//настройка Identity для работы с 1- класслм AppUser 2- выбор посредника для работы с БД
builder.Services
    .AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Account/Login");

//Добавляем локализацию
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(
    options =>
    {
        var supportedCulture = new[]
        {
            new CultureInfo("kk-KZ"),
            new CultureInfo("ru-RU"),
            new CultureInfo("en-US")
        };

        options.DefaultRequestCulture = new RequestCulture(culture: "kk-KZ", uiCulture: "kk-KZ");
        options.SupportedCultures = supportedCulture;
        options.SupportedUICultures = supportedCulture;
    });


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Log/hotelatrLog.txt", rollingInterval: RollingInterval.Hour)
    .MinimumLevel.Debug()
    .WriteTo.Seq("http://localhost:5341")
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

var supportedCulture = new[] { "kk-KZ", "ru-RU", "en-US" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("kk-KZ")
    .AddSupportedCultures(supportedCulture)
    .AddSupportedUICultures(supportedCulture);

app.UseRequestLocalization(localizationOptions);


app.UseRouting();

//---->
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
