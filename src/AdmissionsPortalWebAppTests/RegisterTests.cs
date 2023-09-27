using AdmissionsPortalWebAppTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsPortalWebAppTests;

[Collection(nameof(CollectionDef))]
public class RegisterTests
{
    AdmissionsPortalWebAppFactory factory;

    public RegisterTests(AdmissionsPortalWebAppFactory factory)
    {
        this.factory = factory;
    }

    [Fact(Skip = "等待实现。")]
    public async Task RegisterNewUserAsync()
    {
        var client = this.factory.CreateClient();

        var getResponse = await client.GetAsync("/Identity/Account/Register");
        var doc = await HtmlHelpers.GetDocumentAsync(getResponse);
    }
}
