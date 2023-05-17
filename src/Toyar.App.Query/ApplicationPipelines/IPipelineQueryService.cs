using Toyar.App.Dto;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto.Applications;

namespace Toyar.App.Query.Pipelines;

public interface IPipelineQueryService : IScopedDependency
{
    /// <summary>
    /// 分页获取流水线列表
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<PageBaseResult<PipelineOutputDto>> GetPipelinePageListAsync(string appId, PipelineQueryDto query);
    
    /// <summary>
    /// 获取流水线详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<PipelineOutputDto> GetApplicationPipelineDetailForIdAsync(string id);


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
    Task<PageBaseResult<ApplicationPipelineExecutedRecordOutputDto>> GetPipelineExecutedRecordPageListAsync(string applicationPipelineId, ApplicationPipelineExecutedQueryDto query);
}