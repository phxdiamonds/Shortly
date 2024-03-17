using Microsoft.EntityFrameworkCore;
using Shortly_Client.Data;
using Shortly_Data;
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
DbInitializer.SeedDefautData(app);  

app.Run();
