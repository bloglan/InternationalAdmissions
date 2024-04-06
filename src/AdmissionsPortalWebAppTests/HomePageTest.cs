namespace AdmissionsPortalWebAppTests;

[Collection(nameof(CollectionDef))]
public class HomePageTest(AdmissionsPortalWebAppFactory factory)
{
    [Theory]
    [InlineData("/")]
    [InlineData("/Index")]
    public async Task Test1(string url)
    {
        var client = factory.CreateClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType!.ToString());
    }
}