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

//��Ʒ����
builder.Services.Configure<ProductInfo>(builder.Configuration.GetSection("ProductInfo"));

//������Դ
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

//����ͱ��ػ�
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

//�û���Ϣ�洢
builder.Services.AddDbContext<PersonIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), s =>
    {
        s.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
    });
});
//ѧ�������洢
builder.Services.AddDbContext<StudentDocumentDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), s =>
    {
        s.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
    });
});

//�û��˻��ͱ�ʶ
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

//Cookieѡ��
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

//��Ȩ����
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
            Console.Write("���������ɾ�����ݿ⣬���Ҳ��ɻָ�����ȷ���Ƿ�ִ�иò�����[y/n]");
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
                Console.WriteLine("��ȡ��������");
            }
            Console.WriteLine("���˳�����");
            return;
        case "upgrade":
            //Apply migrations
            identityDbContext.Database.Migrate();
            studentDbContext.Database.Migrate();
            break;
        default:
            throw new ArgumentException("�޷�ʶ��Ĳ�����", "database-action");
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

//������init����ʱ��ִ�����ݿ��ʼ������


app.Run();


namespace AdmissionsPortalWebApp
{
    /// <summary>
    /// Definitions for Testing.
    /// </summary>
    public partial class Program;
}