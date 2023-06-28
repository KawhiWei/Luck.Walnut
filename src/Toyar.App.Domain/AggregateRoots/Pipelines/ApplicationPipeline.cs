using System.Text;
using System.Text.Json;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Toyar.App.Domain.AggregateRoots.Applications;
using Toyar.App.Domain.AggregateRoots.ComponentIntegrations;
using Toyar.App.Domain.AggregateRoots.ValueObjects.PipelinesValueObjects;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto.ComponentIntegrations;

namespace Toyar.App.Domain.AggregateRoots.Pipelines;

public class ApplicationPipeline : FullAggregateRoot
{

    public ApplicationPipeline(string appId, string name, bool published, string buildComponentId, string continuousIntegrationImage, string imageWareHouseComponentId)
    {
        AppId = appId;
        Name = name;
        Published = published;
        BuildComponentId = buildComponentId;
        ContinuousIntegrationImage = continuousIntegrationImage;
        ImageWareHouseComponentId = imageWareHouseComponentId;
    }

    /// <summary>
    /// 
    /// </summary>
    public string AppId { get; private set; }

    /// <summary>
    /// 流水线名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 流水线集成Id
    /// </summary>
    public string BuildComponentId { get; private set; }

    /// <summary>
    /// CI Runner 镜像Id
    /// </summary>
    public string ContinuousIntegrationImage { get; private set; }

    /// <summary>
    /// 镜像仓库组件Id
    /// </summary>
    public string ImageWareHouseComponentId { get; private set; }

    /// <summary>
    /// 是否发布
    /// </summary>
    public bool Published { get; private set; }

    /// <summary>
    /// Jenkins下一次Build的Id
    /// </summary>
    public int NextBuildNumber { get; private set; } = default!;

    /// <summary>
    /// 流水线Dsl
    /// </summary>
    public ICollection<Stage> PipelineScript { get; private set; } = new HashSet<Stage>();

    /// <summary>
    /// 执行记录
    /// </summary>
    public ICollection<PipelineHistory> PipelineHistories { get; private set; } = new HashSet<PipelineHistory>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pipelineScript"></param>
    /// <returns></returns>
    public ApplicationPipeline SetPipelineScript(ICollection<Stage> pipelineScript)
    {
        PipelineScript = pipelineScript;
        return this;
    }

    public ApplicationPipeline SetName(string name)
    {
        Name = name;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buildComponentId"></param>
    /// <returns></returns>
    public ApplicationPipeline SetBuildComponentId(string buildComponentId)
    {
        BuildComponentId = buildComponentId;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buildComponentId"></param>
    /// <returns></returns>
    public ApplicationPipeline SetContinuousIntegrationImage(string continuousIntegrationImage)
    {
        ContinuousIntegrationImage = continuousIntegrationImage;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buildComponentId"></param>
    /// <returns></returns>
    public ApplicationPipeline SetImageWareHouseComponentId(string imageWareHouseComponentId)
    {
        ImageWareHouseComponentId = imageWareHouseComponentId;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="published"></param>
    /// <returns></returns>
    public ApplicationPipeline SetPublished(bool published)
    {
        Published = published;
        return this;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="published"></param>
    /// <returns></returns>
    public PipelineHistory GetExecutedRecordForJenkinsNumber(uint jenkinsNumber)
    {
        var applicationPipelineExecutedRecord= PipelineHistories.FirstOrDefault(r => r.JenkinsBuildNumber == jenkinsNumber);
        if(applicationPipelineExecutedRecord is null)
        {
            throw new BusinessException($"{Name}-------{jenkinsNumber}执行记录不存在");
        }
        return applicationPipelineExecutedRecord;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="nextBuildNumber"></param>
    /// <returns></returns>
    public ApplicationPipeline AddApplicationPipelineExecutedRecord(uint nextBuildNumber,string imageVersion)
    {
        var applicationPipelineExecutedRecord = new PipelineHistory(this.Id, PipelineBuildStateEnum.Running, this.PipelineScript, nextBuildNumber, imageVersion);
        PipelineHistories.Add(applicationPipelineExecutedRecord);
        return this;
    }
    
    
    public string  GetPipelineScript(Application application, ComponentIntegration componentIntegration)
    {
        var stringBuilder = new StringBuilder();
        foreach (var stage in this.PipelineScript)
        {
            stringBuilder.Append($@"
            stage('{stage.Name}')
            {{
                steps {{");
            foreach (var step in stage.Steps)
            {
                switch (step.StepType)
                {
                    case StepTypeEnum.PullCode:
                        var pipelinePullCodeStep = step.Content.Deserialize<PipelinePullCodeStepDto>(new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        if(pipelinePullCodeStep is null)
                        {
                            break;
                        }
                        stringBuilder.Append($@"
                        checkout([
                             $class: 'GitSCM', branches: [[name: ""${{BRANCH_NAME}}""]],
                             doGenerateSubmoduleConfigurations: false,extensions: [[$class:'CheckoutOption',timeout:30],[$class:'CloneOption',depth:0,noTags:false,reference:'',shallow:false,timeout:3600]], submoduleCfg: [],
                             userRemoteConfigs: [[ url: ""{application.GitUrl}""]]
                        ])");
                        break;
                    case StepTypeEnum.CompilePublish:
                        var compilePublishStep = step.Content.Deserialize<PipelineBuildImageStepDto>(new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        if (compilePublishStep is null)
                        {
                            break;
                        }
                        stringBuilder.Append($@"
                        container('build') {{
                        sh '''
                        {compilePublishStep.CompileScript}
                        '''
                        }}");
                        break;
                    case StepTypeEnum.DockerFilePublishAndBuildImage:
                        var pipelineBuildImageStep = step.Content.Deserialize<PipelineDockerPublishAndBuildImageStepDto>(new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        if (pipelineBuildImageStep is null)
                        {
                            break;
                        }

                        var dockerRegistry = new DockerRegistry()
                        {
                            Auths = new Dictionary<string, AuthDto>()
                        };
                        byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes($"{componentIntegration.Credential.UserName}:{componentIntegration.Credential.PassWord}");
                        dockerRegistry.Auths.Add($"{componentIntegration.Credential.ComponentLinkUrl}", new AuthDto()
                        {
                            Auth= Convert.ToBase64String(toEncodeAsBytes)
                        });
                        
                        var jsonStr = dockerRegistry.Serialize(new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        stringBuilder.Append($@"
                        container('docker') {{
                            sh '''#!/busybox/sh -e
                               echo '{jsonStr}' > /kaniko/.docker/config.json
                            '''
                            sh '''#!/busybox/sh 
                               /kaniko/executor -f {pipelineBuildImageStep.DockerFileSrc} -c . --destination={componentIntegration.Credential.ComponentLinkUrl}/toyar/{application.AppId.ToLower()}:""${{BRANCH_NAME}}""""${{VERSION_NAME}}""  --insecure --skip-tls-verify -v=debug
                            '''
                        }}");
                        break;
                    case StepTypeEnum.ExecuteCommand:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            stringBuilder.Append(@"
                }
            }");
        }

        return stringBuilder.ToString();
    }

    
}