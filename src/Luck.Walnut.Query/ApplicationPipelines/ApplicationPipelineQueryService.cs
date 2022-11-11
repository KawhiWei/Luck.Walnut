using Luck.Walnut.Adapter.JenkinsAdapter;
using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.ApplicationPipelines;

namespace Luck.Walnut.Query.ApplicationPipelines;

public class ApplicationPipelineQueryService : IApplicationPipelineQueryService
{
    private readonly IApplicationPipelineRepository _applicationPipelineRepository;

    private readonly IComponentIntegrationRepository _componentIntegrationRepository;
    private readonly IJenkinsIntegration _jenkinsIntegration;

    public ApplicationPipelineQueryService(IApplicationPipelineRepository applicationPipelineRepository, IJenkinsIntegration jenkinsIntegration, IComponentIntegrationRepository componentIntegrationRepository)
    {
        _applicationPipelineRepository = applicationPipelineRepository;
        _jenkinsIntegration = jenkinsIntegration;
        _componentIntegrationRepository = componentIntegrationRepository;
    }

    public async Task<PageBaseResult<ApplicationPipelineOutputDto>> GetApplicationPageListAsync(string appId, ApplicationPipelineQueryDto query)
    {
        var result = await _applicationPipelineRepository.GetApplicationPipelinePageListAsync(appId, query);
        return new PageBaseResult<ApplicationPipelineOutputDto>(result.TotalCount, result.Data.ToArray());
    }

    public async Task<ApplicationPipelineOutputDto> GetApplicationDetailForIdAsync(string id)
    {
        var applicationPipeline = await _applicationPipelineRepository.FindFirstByIdAsync(id);
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

    public async Task<string> GetJenkinsJobBuildDetailAsync(string id)
    {
        var applicationPipeline = await _applicationPipelineRepository.FindFirstByIdAsync(id);
        var componentIntegration = await _componentIntegrationRepository.FindFirstByIdAsync(applicationPipeline.ComponentIntegrationId);
        _jenkinsIntegration.BuildJenkinsOptions(componentIntegration.Credential.ComponentLinkUrl, componentIntegration.Credential.UserName ?? "", componentIntegration.Credential.Token ?? "");
        return await _jenkinsIntegration.GetJenkinsJobBuildDetailAsync(applicationPipeline.Name, 23);
        return "";
    }
}