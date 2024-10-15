using AdmissionsPortalWebAppTests.Helpers;

namespace AdmissionsPortalWebAppTests;

[Collection(nameof(CollectionDef))]
public class RegisterTests(AdmissionsPortalWebAppFactory factory)
{
    [Fact(Skip = "等待实现。")]
    public async Task RegisterNewUserAsync()
    {
        var client = factory.CreateClient();

        var getResponse = await client.GetAsync("/Identity/Account/Register");
        var doc = await HtmlHelpers.GetDocumentAsync(getResponse);
    }
}
