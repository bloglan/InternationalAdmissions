using AdmissionsPortalWebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using PersonIdentity;
using PersonIdentityStores;
using StudentDocuments;
using StudentDocumentStores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PersonIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), s =>
    {
        s.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
    });
});
builder.Services.AddDbContext<StudentDocumentDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), s =>
    {
        s.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
    });
});

builder.Services.AddIdentity<Person, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddUserManager<UserManager<Person>>()
    .AddUserStore<PersonStore>()
    .AddEntityFrameworkStores<PersonIdentityDbContext>()
    .AddClaimsPrincipalFactory<PersonClaimsFactory>()
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
    options.Conventions.AuthorizeAreaFolder("Admin", "/", "RequireAdministratorsRole");
    options.Conventions.AuthorizeAreaFolder("Manage", "/", "RequireManagerRole");
    options.Conventions.AuthorizeAreaFolder("Student", "/");
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorsRole", policy => policy.RequireRole("Administrators"));
    options.AddPolicy("RequireManagerRole", policy => policy.RequireRole("Manager"));
});

//Work load
builder.Services.AddScoped<PassportManager>()
    .AddScoped<IPersonPassportStore, PersonPassportStore>();

builder.Services.AddScoped<VisaManager>()
    .AddScoped<IPersonVisaStore, PersonVisaStore>();

//Build WebApplication
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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


app.Run();


namespace AdmissionsPortalWebApp
{
    /// <summary>
    /// Definations for Testing.
    /// </summary>
    public partial class Program { }
}