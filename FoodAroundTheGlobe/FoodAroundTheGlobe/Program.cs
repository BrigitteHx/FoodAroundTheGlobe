using FoodAroundTheGlobe.Data;
using FoodAroundTheGlobe.Services;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1) Services registreren (DI)
builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("Smtp"));
builder.Services.AddTransient<IEmailSender, SmtpEmailSender>();

builder.Services.AddRazorPages();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services
    .AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;

        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = true;

    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 2) App bouwen
var app = builder.Build();

// 3) Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint(); // toont database-migratie pagina in dev
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Static files uit wwwroot (zorg dat de map bestaat)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

