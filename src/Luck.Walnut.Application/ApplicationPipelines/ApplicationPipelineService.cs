using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Adapter.JenkinsAdapter;
using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto.ApplicationPipelines;
using RazorEngine;
using RazorEngine.Templating;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Xml;
using Luck.Framework.Extensions;
using Luck.Walnut.Dto.ComponentIntegrations;
using Microsoft.Extensions.Primitives;

namespace Luck.Walnut.Application.ApplicationPipelines;

public class ApplicationPipelineService : IApplicationPipelineService
{
    private readonly IApplicationPipelineRepository _applicationPipelineRepository;

    private readonly IJenkinsIntegration _jenkinsIntegration;

    private readonly IComponentIntegrationRepository _componentIntegrationRepository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IApplicationRepository _applicationRepository;

    private readonly IApplicationPipelineExecutedRecordRepository _applicationPipelineExecutedRecordRepository;

    public ApplicationPipelineService(IApplicationPipelineRepository applicationPipelineRepository, IUnitOfWork unitOfWork, IJenkinsIntegration jenkinsIntegration, IComponentIntegrationRepository componentIntegrationRepository,
        IApplicationPipelineExecutedRecordRepository applicationPipelineExecutedRecordRepository, IApplicationRepository applicationRepository)
    {
        _applicationPipelineRepository = applicationPipelineRepository;
        _unitOfWork = unitOfWork;
        _jenkinsIntegration = jenkinsIntegration;
        _componentIntegrationRepository = componentIntegrationRepository;
        _applicationPipelineExecutedRecordRepository = applicationPipelineExecutedRecordRepository;
        _applicationRepository = applicationRepository;
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
        applicationPipeline
            .SetName(input.Name).SetPipelineScript(pipelineScript)
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

        var application = await _applicationRepository.FindFirstOrDefaultByAppIdAsync(applicationPipeline.AppId);

        if (application is null)
        {
            throw new BusinessException($"应用不存在!");
        }
        await BuildJenkinsIntegration(applicationPipeline.ComponentIntegrationId);

        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(JenkinsPipeLineTemplates.PipelineXml);
        var node = xmlDocument.SelectSingleNode("flow-definition/definition/script");
        if (node is null)
        {
            throw new BusinessException($"流水线的基础xml格式错误");
        }
        var (buildImage, pipelineScript) = applicationPipeline.GetPipelineScript(application);
        var defaultImageList = GetDefaultContainerList();
        if (!buildImage.IsNullOrEmpty())
        {
            defaultImageList.Add(new Container("build", buildImage, "/home/jenkins/agent").SetCommandArr(new[] { "sleep" }).SetArgsArr(new[] { "99d" }));
        }
        var pipelineMetaData = new PipelineMetaData(defaultImageList, applicationPipeline.PipelineScript.ToList(), pipelineScript);
        var template = GetPipelineTemplate();
        var dslScript = Engine.Razor.RunCompile(template, Guid.NewGuid().ToString(), pipelineMetaData.GetType(), pipelineMetaData);
        node.InnerText = dslScript;

        var job = await _jenkinsIntegration.GetJenkinsJobDetailAsync(applicationPipeline.Name);
        if (job is null)
        {
            await _jenkinsIntegration.CreateJenkinsJobAsync(applicationPipeline.Name, xmlDocument.InnerXml);
        }
        else
        {
            await _jenkinsIntegration.UpdateJenkinsJobAsync(applicationPipeline.Name, xmlDocument.InnerXml);
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
                    applicationPipelineExecutedRecord.SetPipelineBuildState(jenkinsJobDetailDto.Result != "SUCCESS" ? PipelineBuildStateEnum.Fail : PipelineBuildStateEnum.Fail);

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




    private List<Container> GetDefaultContainerList() => new()
    {
        new Container("jnlp", "registry.cn-hangzhou.aliyuncs.com/luck-walunt/inbound-agent:4.10-3-v1", "/home/jenkins/agent"),
        new Container("docker", "registry.cn-hangzhou.aliyuncs.com/luck-walunt/kaniko-executor:v1.9.0-debug-v1", "/home/jenkins/agent").SetCommandArr(new[] { "cat" }),
    };

    /// <summary>
    /// 读取Pipeline模板
    /// </summary>
    /// <returns></returns>
    private string GetPipelineTemplate()
    {
        var projectName = Assembly.GetExecutingAssembly().GetName().Name;
        if (projectName!.IsNullOrEmpty())
        {
            throw new BusinessException("没有找到对应的程序集");
        }
        var resName = $"{projectName}.Templates.JenkinsCIPipeLine.cshtml";
        var stream = GetType().Assembly.GetManifestResourceStream(resName);
        if (stream == null)
        {
            throw new BusinessException("没有找到对应的模板");
        }

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}