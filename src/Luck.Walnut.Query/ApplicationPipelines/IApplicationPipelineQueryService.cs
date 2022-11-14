using Luck.Walnut.Dto;
using Luck.Walnut.Dto.ApplicationPipelines;
using Luck.Walnut.Dto.Applications;

namespace Luck.Walnut.Query.ApplicationPipelines;

public interface IApplicationPipelineQueryService : IScopedDependency
{
    /// <summary>
    /// 分页获取流水线列表
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<PageBaseResult<ApplicationPipelineOutputDto>> GetApplicationPageListAsync(string appId, ApplicationPipelineQueryDto query);
    
    /// <summary>
    /// 获取流水线详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ApplicationPipelineOutputDto> GetApplicationDetailForIdAsync(string id);


    // /// <summary>
    // /// 获取Job执行明细
    // /// </summary>
    // /// <param name="id"></param>
    // /// <returns></returns>
    // Task<object> GetJenkinsJobBuildDetailAsync(string id);

    /// <summary>
    /// 获取Jenkins执行日志
    /// </summary>
    /// <param name="applicationPipelineId"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<string> GetJenkinsJobBuildLogsAsync(string applicationPipelineId, string id);

    /// <summary>
    /// 分页获取执行记录
    /// </summary>
    /// <param name="applicationPipelineId"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<PageBaseResult<ApplicationPipelineExecutedRecordOutputDto>> GetApplicationPipelineExecutedRecordPageListAsync(string applicationPipelineId, ApplicationPipelineExecutedQueryDto query);
}