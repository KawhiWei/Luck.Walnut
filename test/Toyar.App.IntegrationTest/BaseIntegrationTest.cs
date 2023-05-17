using System.Net.Http.Json;
using Luck.AspNetCore.ApiResults;
using Xunit.Abstractions;

namespace Toyar.App.IntegrationTest;

public class BaseIntegrationTest: IClassFixture<LuckTestServerBase>
{
    private readonly ITestOutputHelper _output;
    private readonly LuckTestServerBase _fixture;
    public BaseIntegrationTest(ITestOutputHelper output, LuckTestServerBase fixture)
    {
        _output = output;
        _fixture = fixture;
    }

    protected  async Task<ApiResult?> GetAsync()
    {
        return await  _fixture.TestHttpClient.GetFromJsonAsync<ApiResult>($"/walnut/api/applications/1245451as");
    }
}