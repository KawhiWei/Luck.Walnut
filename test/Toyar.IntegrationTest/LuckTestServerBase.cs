using Microsoft.AspNetCore.Mvc.Testing;

namespace Toyar.IntegrationTest;
public class LuckTestServerBase 
{
    public LuckTestServerBase()
    {
    }
    public HttpClient TestHttpClient { get; }
}