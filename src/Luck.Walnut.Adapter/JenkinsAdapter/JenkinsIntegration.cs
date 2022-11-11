using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using Luck.Framework.Exceptions;

namespace Luck.Walnut.Adapter.JenkinsAdapter;

public class JenkinsIntegration : IJenkinsIntegration
{
    private readonly IHttpClientFactory _httpClientFactory;
    public string UserName { get; set; }
    public string Token { get; set; }
    public string UrlAddress { get; set; }


    public void BuildJenkinsOptions(string urlAddress, string userName, string token)
    {
        UrlAddress = urlAddress;
        UserName = userName;
        Token = token;
    }


    public JenkinsIntegration(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// 获取job执行记录明细
    /// </summary>
    public async Task<string> GetJenkinsJobBuildDetailAsync(string jobName, int buildId)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            SetRequestHeadersBasicAuth(client);
            var response = await client.PostAsync($"{UrlAddress}/job/{jobName}/{buildId}/api/json", null);
            return await HttpResponseMessage(response);
        }
        catch (Exception ex)
        {
            throw new BusinessException("", $"服务器异常", ex);
        }
    }

    /// <summary>
    /// 触发构建一个任务执行build
    /// </summary>
    public async Task<string> BuildJobAsync(string jobName)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            SetRequestHeadersBasicAuth(client);
            var response = await client.PostAsync($"{UrlAddress}/job/{jobName}/build", null);
            return await HttpResponseMessage(response);
        }
        catch (Exception ex)
        {
            throw new BusinessException("", $"服务器异常", ex);
        }
    }


    /// <summary>
    /// 在Jenkins内创建job
    /// </summary>
    public async Task<string> CreateJenkinsJobAsync()
    {
        await Task.CompletedTask;
        var client = _httpClientFactory.CreateClient();
        SetRequestHeadersBasicAuth(client);

        return "";
    }


    /// <summary>
    /// 修改jenkins内的job
    /// </summary>
    public async Task<string> UpdateJenkinsJobAsync()
    {
        await Task.CompletedTask;
        var client = _httpClientFactory.CreateClient();
        SetRequestHeadersBasicAuth(client);
        return "";
    }

    /// <summary>
    /// 删除 Jenkins内的Job
    /// </summary>
    public async Task<string> DeleteJenkinsJobBuildDetailAsync(string jobName)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            SetRequestHeadersBasicAuth(client);
            var response = await client.PostAsync($"{UrlAddress}/job/{jobName}/build", null);
            return await HttpResponseMessage(response);
        }
        catch (Exception ex)
        {
            throw new BusinessException("", $"服务器异常", ex);
        }
    }

    private void SetRequestHeadersBasicAuth(HttpClient client)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{UserName}:{Token}")));
    }

    private async Task<string> HttpResponseMessage(HttpResponseMessage httpResponseMessage)
    {
        switch (httpResponseMessage.StatusCode)
        {
            case HttpStatusCode.OK:
                break;
            case HttpStatusCode.Created:
                break;
            case HttpStatusCode.Unauthorized:
                throw new BusinessException($"用户名或者密码无效");
                break;
            case HttpStatusCode.Forbidden:
                throw new BusinessException($"用户名或者密码无效");
                break;
            case HttpStatusCode.InternalServerError:
                throw new BusinessException($"服务器异常");
                break;
        }

        var responseMessage = await httpResponseMessage.Content.ReadAsStringAsync();
        return responseMessage;
    }
}