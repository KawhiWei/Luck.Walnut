using Toyar.App.Dto.K8s.WorkLoads;

namespace Toyar.App.AppService.K8s.WorkLoads;

public interface IWorkLoadService : IScopedDependency
{
    Task CreateWorkLoadAsync(WorkLoadInputDto input);


    Task UpdateWorkLoadAsync(string id, WorkLoadInputDto input);


    Task PublishWorkLoadAsync(string id);

    /// <summary>
    /// 部署应用
    /// </summary>
    /// <param name="id"></param>
    /// <param name="imageVersion"></param>
    /// <returns></returns>
    Task DeployApplicationAsync(string id, string imageVersion);

    /// <summary>
    /// 修改更新策略
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateWorkLoadStrategyAsync(string id, StrategyInputDto input);

    /// <summary>
    /// 删除部署
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteDeploymentAsync(string id);
}
