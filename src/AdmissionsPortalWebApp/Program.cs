using AdmissionsPortalWebApp;
using AdmissionsPortalWebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using PersonIdentity;
using PersonIdentityStores;
using StudentDocuments;
using StudentDocumentStores;
using System.Globalization;
using Serilog;
using Serilog.Events;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console(
            outputTemplate:
            "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .WriteTo.EventLog(".NET Runtime", restrictedToMinimumLevel: LogEventLevel.Information);
});

//产品配置
builder.Services.Configure<ProductInfo>(builder.Configuration.GetSection("ProductInfo"));

//程序资源
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

//区域和本地化
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("zh-CN"),
    };
    options.DefaultRequestCulture = new RequestCulture(culture: builder.Configuration["DefaultCulture"]!, uiCulture: builder.Configuration["DefaultCulture"]!);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

//用户信息存储
builder.Services.AddDbContext<PersonIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), s =>
    {
        s.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
    });
});
//学生档案存储
builder.Services.AddDbContext<StudentDocumentDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), s =>
    {
        s.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
    });
});

//用户账户和标识
builder.Services.AddIdentity<Person, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
    .AddUserManager<UserManager<Person>>()
    .AddUserStore<PersonStore>()
    .AddEntityFrameworkStores<PersonIdentityDbContext>()
    .AddClaimsPrincipalFactory<PersonClaimsFactory>()
    .AddDefaultTokenProviders();

//Cookie选项
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
})
    .AddViewLocalization()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResource));
    });

//授权策略
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

if (app.Configuration["database-action"] != null)
{
    using var scope = app.Services.CreateScope();
    var identityDbContext = scope.ServiceProvider.GetRequiredService<PersonIdentityDbContext>();
    var studentDbContext = scope.ServiceProvider.GetRequiredService<StudentDocumentDbContext>();

    switch (app.Configuration["database-action"])
    {
        case "reset":
            Console.Write("这个操作将删除数据库，并且不可恢复。请确认是否执行该操作？[y/n]");
            var key = Console.ReadKey(false);
            if (key.KeyChar == 'y')
            {
                identityDbContext.Database.EnsureDeleted();
                studentDbContext.Database.EnsureDeleted();

                //Apply migrations
                identityDbContext.Database.Migrate();
                studentDbContext.Database.Migrate();

                //Init data
                //todo Init Data
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("已取消操作！");
            }
            Console.WriteLine("将退出程序。");
            return;
        case "upgrade":
            //Apply migrations
            identityDbContext.Database.Migrate();
            studentDbContext.Database.Migrate();
            break;
        default:
            throw new ArgumentException("无法识别的参数。", "database-action");
    }
}


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

app.UseRequestLocalization();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

//当带有init参数时，执行数据库初始化任务


app.Run();


namespace AdmissionsPortalWebApp
{
    /// <summary>
    /// Definitions for Testing.
    /// </summary>
    public partial class Program;
}