using Xunit.Abstractions;

namespace Toyar.IntegrationTest;

public class UnitTest1 : BaseIntegrationTest
{
    public UnitTest1(ITestOutputHelper output, LuckTestServerBase fixture) : base(output, fixture)
    {
    }

    [Fact]
    public async Task Test1()
    {
        var appId = Environment.GetEnvironmentVariable("AppId");
        Assert.True(appId == "Toyar.App");
        var result = await GetAsync();
        // Assert.True(result.IsNotNull());
        // Assert.True( result.Result.IsNotNull());
        // _webHostEnvironment.IsDevelopment()
    }
}