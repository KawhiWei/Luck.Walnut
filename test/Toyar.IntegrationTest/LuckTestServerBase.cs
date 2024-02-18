using Microsoft.AspNetCore.Mvc.Testing;

namespace Toyar.IntegrationTest;
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