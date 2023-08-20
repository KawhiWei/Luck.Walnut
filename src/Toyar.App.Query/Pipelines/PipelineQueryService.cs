using Luck.Framework.Extensions;
using Toyar.App.Adapter.JenkinsAdapter;
using Toyar.App.Domain.AggregateRoots.ApplicationPipelines;
using Toyar.App.Domain.Repositories;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto.ValueObjects.PipelinesValueObjects;

namespace Toyar.App.Query.Pipelines;

public class PipelineQueryService : IPipelineQueryService
{
    private readonly IApplicationPipelineRepository _pipelineRepository;
    private readonly IApplicationRepository _applicationRepository;
    private readonly IComponentIntegrationRepository _componentIntegrationRepository;
    private readonly IJenkinsIntegration _jenkinsIntegration;
    private readonly IApplicationPipelineHistoryRepository _applicationPipelineHistoryRepository;

    public PipelineQueryService(IApplicationPipelineRepository applicationPipelineRepository, IJenkinsIntegration jenkinsIntegration, IComponentIntegrationRepository componentIntegrationRepository, IApplicationPipelineHistoryRepository applicationPipelineHistoryRepository, IApplicationRepository applicationRepository)
    {
        _pipelineRepository = applicationPipelineRepository;
        _jenkinsIntegration = jenkinsIntegration;
        _componentIntegrationRepository = componentIntegrationRepository;
        _applicationPipelineHistoryRepository = applicationPipelineHistoryRepository;
        _applicationRepository = applicationRepository;
    }

    public async Task<PageBaseResult<ApplicationPipelineOutputDto>> GetPipelinePageListAsync(string appId, PipelineQueryDto query)
    {
        var (data, totalCount) = await _pipelineRepository.GetApplicationPipelinePageListAsync(appId, query);


        var applicationPipelineExecutedRecordList = await _applicationPipelineHistoryRepository.GetApplicationPipelineExecutedRecordListAsync(data.Select(x => x.Id));

        foreach (var applicationPipeline in data)
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
        return new PageBaseResult<ApplicationPipelineOutputDto>(totalCount, data.ToArray());
    }


    public async Task<PageBaseResult<ApplicationPipelineHistoryOutputDto>> GetPipelineHistoryForPipeLineIdPageListAsync(string applicationPipelineId, ApplicationPipelineHistoryQueryDto query)
    {
        var result = await _applicationPipelineHistoryRepository.GetApplicationPipelineHistoryByPipeLineIdPageListAsync(applicationPipelineId, query);
        
        return new PageBaseResult<ApplicationPipelineHistoryOutputDto>(result.TotalCount, result.Data.Select(StructurePipelineHistoryOutputDto).ToArray());
    }
    public async Task<PageBaseResult<ApplicationPipelineHistoryOutputDto>> GetPipelineHistoryForAppIdPageListAsync(string applicationPipelineId, ApplicationPipelineHistoryQueryDto query)
    {
        var result = await _applicationPipelineHistoryRepository.GetPipelineHistoryForAppIdPageListAsync(applicationPipelineId, query);
        
        return new PageBaseResult<ApplicationPipelineHistoryOutputDto>(result.TotalCount, result.Data.Select(StructurePipelineHistoryOutputDto).ToArray());
    }

    
    
    
    
    public async Task<ApplicationPipelineOutputDto> GetApplicationPipelineDetailForIdAsync(string id)
    {
        var applicationPipeline = await _pipelineRepository.FindFirstByIdAsync(id);
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
            AppId = applicationPipeline.AppId,
            ContinuousIntegrationImage=applicationPipeline.ContinuousIntegrationImage,
            BuildComponentId = applicationPipeline.BuildComponentId,
            ImageWareHouseComponentId = applicationPipeline.ImageWareHouseComponentId,
            Environment = applicationPipeline.Environment,
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


    public async Task<string> GetJenkinsJobBuildLogsAsync(string applicationPipelineId, string id)
    {
        var applicationPipelineExecutedRecord = await _applicationPipelineHistoryRepository.FindFirstByIdAsync(id);
        var applicationPipeline = await _pipelineRepository.FindFirstByIdAsync(applicationPipelineId);
        var componentIntegration = await _componentIntegrationRepository.FindFirstByIdAsync(applicationPipeline.BuildComponentId);
        _jenkinsIntegration.BuildJenkinsOptions(componentIntegration.Credential.ComponentLinkUrl, componentIntegration.Credential.UserName ?? "", componentIntegration.Credential.PassWord ?? "");
        return await _jenkinsIntegration.GetJenkinsJobBuildLogsAsync($"{applicationPipeline.AppId}.{applicationPipeline.Name}", applicationPipelineExecutedRecord.JenkinsBuildNumber);
    }
    
    
    private static ApplicationPipelineHistoryOutputDto StructurePipelineHistoryOutputDto(ApplicationPipelineHistory applicationPipelineHistory)
    {
        return new ApplicationPipelineHistoryOutputDto
        {
            Id = applicationPipelineHistory.Id,
            PipelineBuildState = applicationPipelineHistory.PipelineBuildState,
            ApplicationPipelineId = applicationPipelineHistory.PipelineId,
            JenkinsBuildNumber = applicationPipelineHistory.JenkinsBuildNumber,
            ImageVersion = applicationPipelineHistory.ImageVersion,
            CreationTime=applicationPipelineHistory.CreationTime,
            CreateUser=applicationPipelineHistory.CreateUser.IsNullOrEmpty()?"Toyar(PaaS)":applicationPipelineHistory.CreateUser,
        };

    }
}