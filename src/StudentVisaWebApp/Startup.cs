using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using StudentVisaEF;
using StudentVisaIdentity;
using StudentVisaWebApp.Services;

namespace StudentVisaWebApp;

internal static class Startup
{

    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.

        builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), s =>
            {
                s.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name);
            });
        });
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
            
        })
            .AddUserManager<UserManager<ApplicationUser>>()
            .AddUserStore<ApplicationUserStore>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddClaimsPrincipalFactory<ApplicationUserClaimsFactory>()
            .AddDefaultTokenProviders();
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Identity/Account/Login";
            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        });

        builder.Services.AddScoped<IEmailSender, NopEmailSender>();

        builder.Services.AddRazorPages(options =>
        {
            options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
            options.Conventions.AuthorizeAreaFolder("Manage", "/", "RequireManagerRole");
            options.Conventions.AuthorizeAreaFolder("Student", "/");
            options.Conventions.AuthorizeFolder("/Admin", "RequireAdministratorsRole");
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireAdministratorsRole", policy =>
            {
                policy.RequireRole("Administrators");
            });
            options.AddPolicy("RequireManagerRole", policy =>
            {
                policy.RequireRole("Manager");
            });
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();

        return app;
    }
}
