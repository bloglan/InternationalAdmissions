using AdmissionStores;
using DatabaseTool;
using DatabaseTool.Migrators;
using Microsoft.EntityFrameworkCore;
using PersonIdentityStores;
using StudentDocumentStores;

IHostBuilder builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices((context, services) =>
{
    //用户信息存储
    services.AddDbContext<PersonIdentityDbContext>(options =>
    {
        options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"), s =>
        {
            s.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
        });
    });
    //学生档案存储
    services.AddDbContext<StudentDocumentDbContext>(options =>
    {
        options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"), s =>
        {
            s.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
        });
    });
    //招生档案
    services.AddDbContext<AdmissionDbContext>(options =>
    {
        options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"), s =>
        {
            s.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
        });
    });

    //注册迁移器
    services.AddScoped<DatabaseMigrator, PersonIdentityMigrator>();
    services.AddScoped<DatabaseMigrator, StudentDocumentMigrator>();
    services.AddScoped<DatabaseMigrator, AdmissionsMigrator>();

    //迁移执行器
    services.AddScoped<DatabaseExecutor>().Configure<DatabaseExecutorOptions>(options =>
    {
        options.DropDatabase = bool.Parse(context.Configuration["DropDatabase"] ?? "false");
        options.AddTestingData = bool.Parse(context.Configuration["AddTestingData"] ?? "false");
    });
});

IHost host = builder.Build();

await using AsyncServiceScope scope = host.Services.CreateAsyncScope();
var executor = scope.ServiceProvider.GetRequiredService<DatabaseExecutor>();
await executor.ExecuteAsync();