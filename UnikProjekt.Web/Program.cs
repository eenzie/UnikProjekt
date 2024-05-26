using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UnikProjekt.Web.Data;
using UnikProjekt.Web.Models;
using UnikProjekt.Web.ProxyServices;
using UnikProjekt.Web.Services;


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
builder.Services.AddDefaultIdentity<ApplicationUser>()
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


builder.Services.AddControllersWithViews();


//IHttpClientFactory
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IUserServiceProxy, UserServiceProxy>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"]);
});

builder.Services.AddHttpClient<IUserRoleServiceProxy, UserRoleServiceProxy>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"]);
});

builder.Services.AddHttpClient<IDocumentServiceProxy, DocumentServiceProxy>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"]);
});

builder.Services.AddHttpClient<IRoleServiceProxy, RoleServiceProxy>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"]);
});

builder.Services.AddHttpClient<IEmailServiceProxy, EmailServiceProxy>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["UnikBaseUrl"]);
});


builder.Services.AddScoped<UserClaimsService>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<UserRoleService>();
builder.Services.AddScoped<DocumentService>();

builder.Services.AddScoped<EmailService>();

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy(
//        "ResidenceRequirementPolicy",
//        policyBuilder => policyBuilder.AddRequirements(
//            new ResidenceRequirement()
//        ));
//});

builder.Services.AddRazorPages();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
