using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Luck.Walnut.Dto.Jenkinses;

namespace Luck.Walnut.Adapter.JenkinsAdapter;

public class JenkinsIntegration : IJenkinsIntegration
{
    private readonly IHttpClientFactory _httpClientFactory;
    public string UserName { get; set; }
    public string Token { get; set; }
    public string UrlAddress { get; set; }


    public JenkinsIntegration(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public void BuildJenkinsOptions(string urlAddress, string userName, string token)
    {
        UrlAddress = urlAddress;
        UserName = userName;
        Token = token;
    }


    /// <summary>
    /// 获取job执行记录明细
    /// </summary>
    public async Task<JenkinsJobDetailDto?> GetJenkinsJobBuildDetailAsync(string jobName, uint buildId)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            SetRequestHeadersBasicAuth(client);
            var response = await client.PostAsync($"{UrlAddress}/job/{jobName}/{buildId}/api/json", null);
            var responseString = await HttpResponseMessage(response);
            if (responseString.Contains("Error 404 Not Found"))
            {
                return null;
            }
            var jenkinsJobDetailDto = responseString.Deserialize<JenkinsJobDetailDto>(new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return jenkinsJobDetailDto;
        }
        catch (Exception ex)
        {
            throw new BusinessException("", $"服务器异常", ex);
        }
    }

    /// <summary>
    /// 获取job执行记录明细
    /// </summary>
    public async Task<JenkinsJobDetailDto?> GetJenkinsJobDetailAsync(string jobName)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            SetRequestHeadersBasicAuth(client);
            var response = await client.PostAsync($"{UrlAddress}/job/{jobName}/api/json", null);
            var responseString = await HttpResponseMessage(response);
            if (responseString.Contains("Error 404 Not Found"))
            {
                return null;
            }
            var jenkinsJobDetailDto = responseString.Deserialize<JenkinsJobDetailDto>(new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return jenkinsJobDetailDto;
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
    /// 查询Jenkins执行Job的日志
    /// </summary>
    public async Task<string> GetJenkinsJobBuildLogsAsync(string jobName, uint buildId)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            SetRequestHeadersBasicAuth(client);
            var response = await client.GetAsync($"{UrlAddress}/job/{jobName}/{buildId}/logText/progressiveText?start=0");
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
    public async Task<string> CreateJenkinsJobAsync(string jobName,string xmlBody)
    {
        var client = _httpClientFactory.CreateClient();
        SetRequestHeadersBasicAuth(client);
        var response = await client.PostAsync($"{UrlAddress}/createItem?name={jobName}",new StringContent(xmlBody,Encoding.UTF8,"application/xml"));
        return await HttpResponseMessage(response);
    }


    /// <summary>
    /// 修改jenkins内的job
    /// </summary>
    public async Task<string> UpdateJenkinsJobAsync(string jobName,string xmlBody)
    {
        var client = _httpClientFactory.CreateClient();
        SetRequestHeadersBasicAuth(client);
        var response = await client.PostAsync($"{UrlAddress}/job/{jobName}/config.xml",new StringContent(xmlBody,Encoding.UTF8,"application/xml"));
        return await HttpResponseMessage(response);
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
            case HttpStatusCode.Forbidden:
                throw new BusinessException($"用户名或者密码无效");
            case HttpStatusCode.InternalServerError:
                throw new BusinessException($"服务器异常");
        }

        var responseMessage = await httpResponseMessage.Content.ReadAsStringAsync();
        return responseMessage;
    }
}