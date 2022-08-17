using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Luck.Walnut.IntegrationTest;
public class LuckTestServerBase 
{
    public LuckTestServerBase()
    {
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                });
            });
        TestHttpClient = application.CreateClient();
    }
    public HttpClient TestHttpClient { get; }
}