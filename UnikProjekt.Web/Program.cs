using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UnikProjekt.Web.Data;
using UnikProjekt.Web.Models;
using UnikProjekt.Web.ProxyServices;


var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString,
//   x => x.MigrationsAssembly("UnikProject.Web.Data.Migrations")));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>()
//builder.Services.AddDefaultIdentity<ApplicationUser>()
//    .AddDefaultTokenProviders()
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddControllersWithViews();

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


//IHttpClientFactory
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IUserServiceProxy, UserServiceProxy>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"]);
});




//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy(
//        "ResidenceRequirementPolicy",
//        policyBuilder => policyBuilder.AddRequirements(
//            new ResidenceRequirement()
//        ));
//});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
