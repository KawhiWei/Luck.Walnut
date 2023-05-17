using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto.Jenkinses;

namespace Toyar.App.Adapter.JenkinsAdapter;

public interface IJenkinsIntegration : IScopedDependency
{
    /// <summary>
    /// 用户名
    /// </summary>
    string UserName { get;   set;}

    /// <summary>
    /// 密钥
    /// </summary>
    string Token { get;   set;}

    /// <summary>
    /// 基础Url地址
    /// </summary>
    string UrlAddress { get; set; }

    /// <summary>
    /// 初始化Jenkins参数
    /// </summary>
    /// <param name="urlAddress"></param>
    /// <param name="userName"></param>
    /// <param name="token"></param>
    void BuildJenkinsOptions(string urlAddress, string userName, string token);
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<string> CreateJenkinsJobAsync(string jobName,string xmlBody);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<string> UpdateJenkinsJobAsync(string jobName,string xmlBody);

    /// <summary>
    /// 获取任务明细
    /// </summary>
    /// <param name="jobName"></param>
    /// <returns></returns>
    Task<JenkinsJobDetailDto?> GetJenkinsJobDetailAsync(string jobName);
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<JenkinsJobDetailDto?> GetJenkinsJobBuildDetailAsync(string jobName,uint buildId);


    /// <summary>
    /// 触发构建一个任务执行build
    /// </summary>
    /// <returns></returns>
    Task<string> BuildJobAsync(string jobName);

    /// <summary>
    /// 带有参数执行构建脚本
    /// </summary>
    /// <param name="jobName"></param>
    /// <param name="jenkinsBuildParaMeter"></param>
    /// <returns></returns>
    Task<string> BuildJobWithParametersAsync(string jobName, IDictionary<string,string> paramsDic);

    /// <summary>
    /// 删除 JenkinsJob
    /// </summary>
    /// <returns></returns>
    Task<string> DeleteJenkinsJobBuildDetailAsync(string jobName);

    /// <summary>
    /// 查询Jenkins执行Job的日志
    /// </summary>
    /// <param name="jobName"></param>
    /// <param name="buildId"></param>
    /// <returns></returns>
    Task<string> GetJenkinsJobBuildLogsAsync(string jobName, uint buildId);
}