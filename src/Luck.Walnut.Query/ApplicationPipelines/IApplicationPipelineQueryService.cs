using Luck.Walnut.Dto;
using Luck.Walnut.Dto.ApplicationPipelines;
using Luck.Walnut.Dto.Applications;

namespace Luck.Walnut.Query.ApplicationPipelines;

public interface IApplicationPipelineQueryService : IScopedDependency
{
    Task<PageBaseResult<ApplicationPipelineOutputDto>> GetApplicationPageListAsync(string appId, ApplicationPipelineQueryDto query);


    Task<ApplicationPipelineOutputDto> GetApplicationDetailForIdAsync(string id);
}