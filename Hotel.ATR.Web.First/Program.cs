using FluentValidation;
using Hotel.ATR.Web.First.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddViewLocalization();

builder.Services.AddScoped<IValidator<ContactForm>, ContactFormValidator>();

//настройка посредника для подключения к БазеДанных
string conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
options.UseSqlServer(conn));

//настройка Identity для работы с 1- класслм AppUser 2- выбор посредника для работы с БД
builder.Services
    .AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Account/Login");

//Добавляем локализацию
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//---->
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
