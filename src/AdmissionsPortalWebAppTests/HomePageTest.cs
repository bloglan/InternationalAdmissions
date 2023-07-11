namespace AdmissionsPortalWebAppTests;

public class HomePageTest : IClassFixture<AdmissionsPortalWebAppFactory>
{
    private readonly AdmissionsPortalWebAppFactory factory;

    public HomePageTest(AdmissionsPortalWebAppFactory factory)
    {
        this.factory = factory;
    }

    [Theory]
    [InlineData("/")]
    [InlineData("/Index")]
    public async Task Test1(string url)
    {
        var client = this.factory.CreateClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType!.ToString());
    }
}