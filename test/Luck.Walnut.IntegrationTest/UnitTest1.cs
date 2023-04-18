using System.Security.Cryptography;
using System.Text;
using Luck.Framework.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Xunit.Abstractions;

namespace Luck.Walnut.IntegrationTest;

public class UnitTest1 : BaseIntegrationTest
{
    public UnitTest1(ITestOutputHelper output, LuckTestServerBase fixture) : base(output, fixture)
    {
    }

    [Fact]
    public async Task Test1()
    {
        var appId = Environment.GetEnvironmentVariable("AppId");
        Assert.True(appId == "Luck.Walnut");
        var result = await GetAsync();
        // Assert.True(result.IsNotNull());
        // Assert.True( result.Result.IsNotNull());
        // _webHostEnvironment.IsDevelopment()
    }
}