using WebHousingAssociation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ThemeService>();
builder.Services.AddScoped<TextService>();
builder.Services.AddScoped<AssociationInfoService>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SecurityLevel1", policy =>
    {
        // Tilføj krav ...
        policy.RequireRole("Administrator");
    });
});


builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
