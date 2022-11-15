using System.Text;
using Luck.Framework.Extensions;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Adapter.JenkinsAdapter;
using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto.ApplicationPipelines;

namespace Luck.Walnut.Application.ApplicationPipelines;

public class ApplicationPipelineService : IApplicationPipelineService
{
    private readonly IApplicationPipelineRepository _applicationPipelineRepository;

    private readonly IJenkinsIntegration _jenkinsIntegration;

    private readonly IComponentIntegrationRepository _componentIntegrationRepository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IApplicationPipelineExecutedRecordRepository _applicationPipelineExecutedRecordRepository;

    public ApplicationPipelineService(IApplicationPipelineRepository applicationPipelineRepository, IUnitOfWork unitOfWork, IJenkinsIntegration jenkinsIntegration, IComponentIntegrationRepository componentIntegrationRepository,
        IApplicationPipelineExecutedRecordRepository applicationPipelineExecutedRecordRepository)
    {
        _applicationPipelineRepository = applicationPipelineRepository;
        _unitOfWork = unitOfWork;
        _jenkinsIntegration = jenkinsIntegration;
        _componentIntegrationRepository = componentIntegrationRepository;
        _applicationPipelineExecutedRecordRepository = applicationPipelineExecutedRecordRepository;
    }

    public async Task CreateAsync(ApplicationPipelineInputDto input)
    {
        var pipelineScript = input.PipelineScript.Select(stage =>
            {
                var stageList = stage.Steps.Select(step => new Step(step.Name, step.StepType, step.Content));
                return new Stage(stage.Name, stageList.ToList());
            }
        ).ToList();
        var applicationPipeline = new ApplicationPipeline(input.AppId, input.Name, pipelineScript, input.AppEnvironmentId, false, input.ComponentIntegrationId);
        _applicationPipelineRepository.Add(applicationPipeline);
        await _unitOfWork.CommitAsync();
    }


    public async Task UpdateAsync(string id, ApplicationPipelineInputDto input)
    {
        var pipelineScript = input.PipelineScript.Select(stage =>
            {
                var stageList = stage.Steps.Select(step => new Step(step.Name, step.StepType, step.Content));
                return new Stage(stage.Name, stageList.ToList());
            }
        ).ToList();
        var applicationPipeline = await GetApplicationPipelineByIdAsync(id);
        applicationPipeline.SetPipelineScript(pipelineScript)
            .SetComponentIntegrationId(input.ComponentIntegrationId).SetPublished(false);
        _applicationPipelineRepository.Update(applicationPipeline);
        await _unitOfWork.CommitAsync();
    }

    /// <summary>
    /// 发布流水线
    /// </summary>
    /// <param name="id"></param>
    public async Task PublishAsync(string id)
    {
        var applicationPipeline = await GetApplicationPipelineByIdAsync(id);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(JenkinsPipeLineTemplates.PipelineTemplate);
        stringBuilder.Append(@"    stages {");
        // JenkinsPipeLineTemplates.CIPipelineXml
        foreach (var stage in applicationPipeline.PipelineScript)
        {
            stringBuilder.Append($@"
            stage('{stage.Name}')");
            stringBuilder.Append(@" {");
            foreach (var step in stage.Steps)
            {
                stringBuilder.Append(@"
                steps {");
                switch (step.StepType)
                {
                    case StepTypeEnum.PullCode:
                        stringBuilder.Append(@"
                        checkout([
                             $class: 'GitSCM', branches: [[name: ""main""]],
                             doGenerateSubmoduleConfigurations: false,extensions: [[$class:'CheckoutOption',timeout:30],[$class:'CloneOption',depth:0,noTags:false,reference:'',shallow:false,timeout:3600]], submoduleCfg: [],
                             userRemoteConfigs: [[ url: ""https://github.com/GeorGeWzw/Luck.Walnut.dashboard.git""]]
                        ])
                }");
                        break;
                    case StepTypeEnum.BuildDockerImage:
                        break;
                    case StepTypeEnum.ExecuteCommand:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            stringBuilder.Append(@"
        }");
        }
        stringBuilder.Append(@" 
    }");
        stringBuilder.Append(@"
}");
        await BuildJenkinsIntegration(applicationPipeline.ComponentIntegrationId);
        var job= await _jenkinsIntegration.GetJenkinsJobDetailAsync(applicationPipeline.Name);
        var xmlBody = JenkinsPipeLineTemplates.PipelineXml;
        var replace = xmlBody.Replace("@Pipeline", stringBuilder.ToString());
        if (job is null)
        {
            await _jenkinsIntegration.CreateJenkinsJobAsync(applicationPipeline.Name,replace);
        }
        else
        {
            await _jenkinsIntegration.UpdateJenkinsJobAsync(applicationPipeline.Name,replace);
        }
        applicationPipeline.SetPublished(true);
        await _unitOfWork.CommitAsync();
    }

    /// <summary>
    /// 执行一次job
    /// </summary>
    /// <param name="id"></param>
    public async Task ExecuteJobAsync(string id)
    {
        var applicationPipeline = await GetApplicationPipelineByIdAsync(id);
        await BuildJenkinsIntegration(applicationPipeline.ComponentIntegrationId);
        var jenkinsJobDetailDto = await _jenkinsIntegration.GetJenkinsJobDetailAsync(applicationPipeline.Name);
        if (jenkinsJobDetailDto is not null)
        {
            applicationPipeline.AddApplicationPipelineExecutedRecord(jenkinsJobDetailDto.NextBuildNumber);
        }

        await _jenkinsIntegration.BuildJobAsync(applicationPipeline.Name);
        await _unitOfWork.CommitAsync();
    }

    /// <summary>
    /// 删除流水线
    /// </summary>
    /// <param name="id"></param>
    public async Task DeleteAsync(string id)
    {
        var applicationPipeline = await _applicationPipelineRepository.FindFirstByIdAsync(id);
        _applicationPipelineRepository.Remove(applicationPipeline);
        await _unitOfWork.CommitAsync();
    }


    private async Task<ApplicationPipeline> GetApplicationPipelineByIdAsync(string id)
    {
        return await _applicationPipelineRepository.FindFirstByIdAsync(id);
    }

    /// <summary>
    /// 使用后台任务的方式同步JenkinsJob执行的状态
    /// </summary>
    public async Task SyncExecutedRecordAsync()
    {
        var list = await _applicationPipelineRepository.GetRunningApplicationPipelineAsync();

        foreach (var applicationPipeline in list)
        {
            await BuildJenkinsIntegration(applicationPipeline.ComponentIntegrationId);
            foreach (var applicationPipelineExecutedRecord in applicationPipeline.ApplicationPipelineExecutedRecords)
            {
                var jenkinsJobDetailDto = await _jenkinsIntegration.GetJenkinsJobBuildDetailAsync(applicationPipeline.Name, applicationPipelineExecutedRecord.JenkinsBuildNumber);
                if (jenkinsJobDetailDto is not null)
                {
                    var logs = await _jenkinsIntegration.GetJenkinsJobBuildLogsAsync(applicationPipeline.Name, applicationPipelineExecutedRecord.JenkinsBuildNumber);
                    switch (jenkinsJobDetailDto.Result)
                    {
                        case "FAILURE":
                            logs = await _jenkinsIntegration.GetJenkinsJobBuildLogsAsync(applicationPipeline.Name, applicationPipelineExecutedRecord.JenkinsBuildNumber);
                            applicationPipelineExecutedRecord.SetPipelineBuildState(PipelineBuildStateEnum.Fail).SetBuildLogs(logs);
                            break;
                        case "SUCCESS":
                            applicationPipelineExecutedRecord.SetPipelineBuildState(PipelineBuildStateEnum.Success).SetBuildLogs(logs);
                            break;
                    }
                }
            }
        }

        await _unitOfWork.CommitAsync();
    }


    private async Task BuildJenkinsIntegration(string componentIntegrationId)
    {
        var componentIntegration = await _componentIntegrationRepository.FindFirstByIdAsync(componentIntegrationId);
        _jenkinsIntegration.BuildJenkinsOptions(componentIntegration.Credential.ComponentLinkUrl, componentIntegration.Credential.UserName ?? "", componentIntegration.Credential.Token ?? "");
    }
}