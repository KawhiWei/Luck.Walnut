using Luck.Walnut.Dto.ApplicationPipelines;

namespace Luck.Walnut.Application.ApplicationPipelines;

public interface IApplicationPipelineService: IScopedDependency
{
    /// <summary>
    /// 创建流水线
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task CreateAsync(ApplicationPipelineInputDto input);

    /// <summary>
    /// 修改流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateAsync(string id, ApplicationPipelineInputDto input);


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
}