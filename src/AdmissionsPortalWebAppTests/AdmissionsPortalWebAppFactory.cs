using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonIdentityStores;
using StudentDocumentStores;

namespace AdmissionsPortalWebAppTests;
public class AdmissionsPortalWebAppFactory : WebApplicationFactory<Program>
{
    protected override TestServer CreateServer(IWebHostBuilder builder)
    {
        TestServer server = base.CreateServer(builder);
        //Ensure and init database
        using var scope = server.Services.CreateScope();
        using var personIdentityDbContext = scope.ServiceProvider.GetRequiredService<PersonIdentityDbContext>();
        using var studentDocumentDbContext = scope.ServiceProvider.GetRequiredService<StudentDocumentDbContext>();

        personIdentityDbContext.Database.EnsureDeleted();
        studentDocumentDbContext.Database.EnsureDeleted();

        personIdentityDbContext.Database.Migrate();
        studentDocumentDbContext.Database.Migrate();
        //apply init data

        scope.Dispose();

        return server;
    }
}
