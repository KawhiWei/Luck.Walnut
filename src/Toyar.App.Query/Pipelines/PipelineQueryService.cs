using Toyar.App.Adapter.JenkinsAdapter;
using Toyar.App.Domain.Repositories;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto.ValueObjects.PipelinesValueObjects;

namespace Toyar.App.Query.Pipelines;

public class PipelineQueryService : IPipelineQueryService
{
    private readonly IPipelineRepository _pipelineRepository;
    private readonly IApplicationRepository _applicationRepository;
    private readonly IComponentIntegrationRepository _componentIntegrationRepository;
    private readonly IJenkinsIntegration _jenkinsIntegration;
    private readonly IApplicationPipelineExecutedRecordRepository _applicationPipelineExecutedRecordRepository;

    public PipelineQueryService(IPipelineRepository applicationPipelineRepository, IJenkinsIntegration jenkinsIntegration, IComponentIntegrationRepository componentIntegrationRepository, IApplicationPipelineExecutedRecordRepository applicationPipelineExecutedRecordRepository, IApplicationRepository applicationRepository)
    {
        _pipelineRepository = applicationPipelineRepository;
        _jenkinsIntegration = jenkinsIntegration;
        _componentIntegrationRepository = componentIntegrationRepository;
        _applicationPipelineExecutedRecordRepository = applicationPipelineExecutedRecordRepository;
        _applicationRepository = applicationRepository;
    }

    public async Task<PageBaseResult<PipelineOutputDto>> GetPipelinePageListAsync(string appId, PipelineQueryDto query)
    {
        var (Data, TotalCount) = await _pipelineRepository.GetApplicationPipelinePageListAsync(appId, query);


        var applicationPipelineExecutedRecordList = await _applicationPipelineExecutedRecordRepository.GetApplicationPipelineExecutedRecordListAsync(Data.Select(x => x.Id));

        foreach (var applicationPipeline in Data)
        {
            var applicationPipelineExecutedRecord = applicationPipelineExecutedRecordList.MaxBy(x => x.JenkinsBuildNumber);
            if (applicationPipelineExecutedRecord is not null)
            {
                applicationPipeline.PipelineBuildState = applicationPipelineExecutedRecord.PipelineBuildState;
                applicationPipeline.JenkinsBuildNumber = applicationPipelineExecutedRecord.JenkinsBuildNumber;
                applicationPipeline.LastApplicationPipelineExecutedRecordId = applicationPipelineExecutedRecord.Id;
            }
            else
            {
                applicationPipeline.PipelineBuildState = PipelineBuildStateEnum.Ready;
            }
        }
        return new PageBaseResult<PipelineOutputDto>(TotalCount, Data.ToArray());
    }


    public async Task<PageBaseResult<ApplicationPipelineExecutedRecordOutputDto>> GetPipelineExecutedRecordPageListAsync(string applicationPipelineId, ApplicationPipelineExecutedQueryDto query)
    {
        var result = await _applicationPipelineExecutedRecordRepository.GetApplicationPipelineExecutedRecordPageListAsync(applicationPipelineId, query);
        return new PageBaseResult<ApplicationPipelineExecutedRecordOutputDto>(result.TotalCount, result.Data.ToArray());
    }

    public async Task<PipelineOutputDto> GetApplicationPipelineDetailForIdAsync(string id)
    {
        var applicationPipeline = await _pipelineRepository.FindFirstByIdAsync(id);
        var application = await _applicationRepository.FindFirstOrDefaultByAppIdAsync(applicationPipeline.AppId);
        if (application is null)
        {
            throw new BusinessException($"应用不存在");
        }
        return new PipelineOutputDto()
        {
            Id = applicationPipeline.Id,
            Name = applicationPipeline.Name,
            Published = applicationPipeline.Published,
            AppEnvironmentId = applicationPipeline.Environment,
            AppId = applicationPipeline.AppId,
            ComponentIntegrationId = applicationPipeline.ComponentIntegrationId,
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

    // public async Task<object> GetJenkinsJobBuildDetailAsync(string id)
    // {
    //     var applicationPipeline = await _applicationPipelineRepository.FindFirstByIdAsync(id);
    //     var componentIntegration = await _componentIntegrationRepository.FindFirstByIdAsync(applicationPipeline.ComponentIntegrationId);
    //     _jenkinsIntegration.BuildJenkinsOptions(componentIntegration.Credential.ComponentLinkUrl, componentIntegration.Credential.UserName ?? "", componentIntegration.Credential.Token ?? "");
    //     return await _jenkinsIntegration.GetJenkinsJobBuildDetailAsync(applicationPipeline.Name, 23);
    //     return "";
    // }


    public async Task<string> GetJenkinsJobBuildLogsAsync(string applicationPipelineId, string id)
    {
        var applicationPipelineExecutedRecord = await _applicationPipelineExecutedRecordRepository.FindFirstByIdAsync(id);
        var applicationPipeline = await _pipelineRepository.FindFirstByIdAsync(applicationPipelineId);
        var componentIntegration = await _componentIntegrationRepository.FindFirstByIdAsync(applicationPipeline.ComponentIntegrationId);
        _jenkinsIntegration.BuildJenkinsOptions(componentIntegration.Credential.ComponentLinkUrl, componentIntegration.Credential.UserName ?? "", componentIntegration.Credential.Token ?? "");
        return await _jenkinsIntegration.GetJenkinsJobBuildLogsAsync(applicationPipeline.Name, applicationPipelineExecutedRecord.JenkinsBuildNumber);
    }
}