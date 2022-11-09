using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.ApplicationPipelines;

namespace Luck.Walnut.Query.ApplicationPipelines;

public class ApplicationPipelineQueryService : IApplicationPipelineQueryService
{
    private readonly IApplicationPipelineRepository _applicationPipelineRepository;

    public ApplicationPipelineQueryService(IApplicationPipelineRepository applicationPipelineRepository)
    {
        _applicationPipelineRepository = applicationPipelineRepository;
    }

    public async Task<PageBaseResult<ApplicationPipelineOutputDto>> GetApplicationPageListAsync(string appId, ApplicationPipelineQueryDto query)
    {
        var result = await _applicationPipelineRepository.GetApplicationPipelinePageListAsync(appId, query);
        return new PageBaseResult<ApplicationPipelineOutputDto>(result.TotalCount, result.Data.ToArray());
    }

    public async Task<ApplicationPipelineOutputDto> GetApplicationDetailForIdAsync(string id)
    {
        var applicationPipeline = await GetApplicationPipelineByIdAsync(id);
        return new ApplicationPipelineOutputDto()
        {
            Id = applicationPipeline.Id,
            Name = applicationPipeline.Name,
            PipelineState = applicationPipeline.PipelineState,
            Published = applicationPipeline.Published,
            AppEnvironmentId = applicationPipeline.AppEnvironmentId,
            PipelineScript = applicationPipeline.PipelineScript.Select(stage =>
            {
                var steps = stage.Steps.Select(step => new StepDto()
                {
                    Name = step.Name,
                    Content = step.Content,
                    StepType = step.StepType,
                }).ToList();
                return new StageDto
                {
                    Name = stage.Name,
                    Steps = steps,
                };
            }).ToList()
        };
    }

    private async Task<ApplicationPipeline> GetApplicationPipelineByIdAsync(string id)
    {
        var applicationPipeline = await _applicationPipelineRepository.FindFirstOrDefaultByIdAsync(id);
        if (applicationPipeline is null)
            throw new BusinessException($"流水线不存在");
        return applicationPipeline;
    }
}