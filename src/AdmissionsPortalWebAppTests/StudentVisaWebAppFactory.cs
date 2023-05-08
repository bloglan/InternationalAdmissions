using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonIdentityStores;
using StudentDocumentStores;

namespace StudentVisaWebAppTests;
public class StudentVisaWebAppFactory : WebApplicationFactory<Program>
{
    protected override TestServer CreateServer(IWebHostBuilder builder)
    {
        TestServer server = base.CreateServer(builder);
        //Ensure and init database
        using var scope = server.Services.CreateScope();
        using var identityDb = scope.ServiceProvider.GetRequiredService<PersonIdentityDbContext>();
        using var db = scope.ServiceProvider.GetRequiredService<StudentDocumentDbContext>();

        identityDb.Database.EnsureDeleted();
        db.Database.EnsureDeleted();

        identityDb.Database.Migrate();
        db.Database.Migrate();
        //apply init data

        scope.Dispose();

        return server;
    }
}
