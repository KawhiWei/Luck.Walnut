using Luck.Framework.Extensions;
using Luck.Walnut.Adapter.JenkinsAdapter;
using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.ApplicationPipelines;

namespace Luck.Walnut.Query.ApplicationPipelines;

public class ApplicationPipelineQueryService : IApplicationPipelineQueryService
{
    private readonly IApplicationPipelineRepository _applicationPipelineRepository;
    private readonly IApplicationRepository _applicationRepository;
    private readonly IComponentIntegrationRepository _componentIntegrationRepository;
    private readonly IJenkinsIntegration _jenkinsIntegration;
    private readonly IApplicationPipelineExecutedRecordRepository _applicationPipelineExecutedRecordRepository;

    public ApplicationPipelineQueryService(IApplicationPipelineRepository applicationPipelineRepository, IJenkinsIntegration jenkinsIntegration, IComponentIntegrationRepository componentIntegrationRepository, IApplicationPipelineExecutedRecordRepository applicationPipelineExecutedRecordRepository, IApplicationRepository applicationRepository)
    {
        _applicationPipelineRepository = applicationPipelineRepository;
        _jenkinsIntegration = jenkinsIntegration;
        _componentIntegrationRepository = componentIntegrationRepository;
        _applicationPipelineExecutedRecordRepository = applicationPipelineExecutedRecordRepository;
        _applicationRepository = applicationRepository;
    }

    public async Task<PageBaseResult<ApplicationPipelineOutputDto>> GetApplicationPipelinePageListAsync(string appId, ApplicationPipelineQueryDto query)
    {
        var (Data, TotalCount) = await _applicationPipelineRepository.GetApplicationPipelinePageListAsync(appId, query);


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
        return new PageBaseResult<ApplicationPipelineOutputDto>(TotalCount, Data.ToArray());
    }


    public async Task<PageBaseResult<ApplicationPipelineExecutedRecordOutputDto>> GetApplicationPipelineExecutedRecordPageListAsync(string applicationPipelineId, ApplicationPipelineExecutedQueryDto query)
    {
        var result = await _applicationPipelineExecutedRecordRepository.GetApplicationPipelineExecutedRecordPageListAsync(applicationPipelineId, query);
        return new PageBaseResult<ApplicationPipelineExecutedRecordOutputDto>(result.TotalCount, result.Data.ToArray());
    }

    public async Task<ApplicationPipelineOutputDto> GetApplicationPipelineDetailForIdAsync(string id)
    {
        var applicationPipeline = await _applicationPipelineRepository.FindFirstByIdAsync(id);
        var application = await _applicationRepository.FindFirstOrDefaultByAppIdAsync(applicationPipeline.AppId);
        if (application is null)
        {
            throw new BusinessException($"应用不存在");
        }
        return new ApplicationPipelineOutputDto()
        {
            Id = applicationPipeline.Id,
            Name = applicationPipeline.Name,
            Published = applicationPipeline.Published,
            AppEnvironmentId = applicationPipeline.AppEnvironmentId,
            AppId = applicationPipeline.AppId,
            ComponentIntegrationId = applicationPipeline.ComponentIntegrationId,
            CodeWarehouseAddress = application.CodeWarehouseAddress,
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
        var applicationPipeline = await _applicationPipelineRepository.FindFirstByIdAsync(applicationPipelineId);
        var componentIntegration = await _componentIntegrationRepository.FindFirstByIdAsync(applicationPipeline.ComponentIntegrationId);
        _jenkinsIntegration.BuildJenkinsOptions(componentIntegration.Credential.ComponentLinkUrl, componentIntegration.Credential.UserName ?? "", componentIntegration.Credential.Token ?? "");
        return await _jenkinsIntegration.GetJenkinsJobBuildLogsAsync(applicationPipeline.Name, applicationPipelineExecutedRecord.JenkinsBuildNumber);
    }
}