using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto;
using Toyar.App.Dto.PipelineTemplates;

namespace Toyar.App.Query.PipelineTemplates
{
    public interface IPipelineTemplateQueryService : IScopedDependency
    {
        /// <summary>
        /// 分页获取流水线列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<PageBaseResult<PipelineOutputDto>> GetPipelineTemplatePageListAsync(PipelineTemplateQueryDto query);

        /// <summary>
        /// 根据Id获取一个流水线模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PipelineTemplateOutputDto?> GetPipelineTemplateByIdFirstOrDefaultAsync(string id);

    }
}
