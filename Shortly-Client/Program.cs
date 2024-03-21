using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shortly_Client.Data;
using Shortly_Data;
using Shortly_Data.Models;
using Shortly_Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configure the AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //using the sql server, define db connection string 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));


 });

//Configure Authentication
//1,Add Identity service
//define identity user and role and these use in Efcore, and will use them with appdbcontext, this defaulttokenprovided to use to generate token for  passowords
//changing email, phone and two factor authentication
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//2,configure app cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true; //accessable only by http requests, its a security feature prevents cross site scripting attacks by not exposing cookie in Js running in browser
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //cookie will expire after 60 minutes
    options.LoginPath = "/Authentication/Login"; //redirect to login page if not authenticated
    options.SlidingExpiration = true; //cookie expiration time is reset to the expired time span
});

//3, Update the default password settings

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false; //password options
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;

    //Lock out settings

    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
});

//Add Services to the container
builder.Services.AddScoped<IUrlsService, UrlService>();
builder.Services.AddScoped<IUsersService, UserService>();

//Here it does check for all the files that are inheriting from the profile, so basically for all the automapper profiles and adds to them container so you can use them
// in the controllers
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "specific",
    pattern: "{controller=Home}/{action=Index}/{userId}/{linkId}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//seed Database
DbInitializer.SeedDefaultUsersAndRolesAsync(app).Wait();   

app.Run();
