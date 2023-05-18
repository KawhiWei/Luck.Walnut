using Toyar.App.Dto.ApplicationPipelines;

namespace Toyar.App.AppService.Pipelines;

public interface IPipelineService: IScopedDependency
{
    /// <summary>
    /// 创建流水线
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task CreateAsync(PipelineInputDto input);

    /// <summary>
    /// 修改流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateAsync(string id, PipelineInputDto input);


    /// <summary>
    /// 发布流水线
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task PublishAsync(string id);

    /// <summary>
    /// 删除流水线
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(string id);

    /// <summary>
    /// 执行一次job
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task ExecuteJobAsync(string id);


    /// <summary>
    /// Webhook同步JenkinsJob执行的状态
    /// </summary>
    /// <param name="id"></param>
    /// <param name="jenkinsBuildNumber"></param>
    /// <returns></returns>
    Task WebHookSyncJenkinsExecutedRecordAsync(string id, uint jenkinsBuildNumber);

    /// <summary>
    /// 使用后台任务的方式同步JenkinsJob执行的状态
    /// </summary>
    /// <returns></returns>
    Task SyncExecutedRecordAsync();
}