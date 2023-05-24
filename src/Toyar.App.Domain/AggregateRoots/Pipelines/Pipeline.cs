using System.Text;
using System.Text.Json;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Toyar.App.Domain.AggregateRoots.Applications;
using Toyar.App.Domain.AggregateRoots.ValueObjects.PipelinesValueObjects;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto.ComponentIntegrations;

namespace Toyar.App.Domain.AggregateRoots.Pipelines;

public class Pipeline : FullAggregateRoot
{

    public Pipeline(string appId, string name, string environment, bool published, string componentIntegrationId,string continuousIntegrationImageId)
    {
        AppId = appId;
        Name = name;
        Environment = environment;
        Published = published;
        ComponentIntegrationId = componentIntegrationId;
        ContinuousIntegrationImageId = continuousIntegrationImageId;
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
    /// 流水线Dsl
    /// </summary>
    public ICollection<Stage> PipelineScript { get; private set; } = new HashSet<Stage>();

    /// <summary>
    /// 
    /// </summary>
    public string Environment { get; private set; }

    /// <summary>
    /// Jenkins下一次Build的Id
    /// </summary>
    public uint NextBuildNumber { get; private set; } = default!;

    /// <summary>
    /// 是否发布
    /// </summary>
    public bool Published { get; private set; }

    /// <summary>
    /// 流水线集成Id
    /// </summary>
    public string ComponentIntegrationId { get; private set; }

    /// <summary>
    /// CI Runner 镜像Id
    /// </summary>
    public string ContinuousIntegrationImageId { get; private set; }

    /// <summary>
    /// 执行记录
    /// </summary>
    public ICollection<PipelineHistory> PipelineHistories { get; private set; } = new HashSet<PipelineHistory>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pipelineScript"></param>
    /// <returns></returns>
    public Pipeline SetPipelineScript(ICollection<Stage> pipelineScript)
    {
        PipelineScript = pipelineScript;
        return this;
    }

    public Pipeline SetName(string name)
    {
        Name = name;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="componentIntegrationId"></param>
    /// <returns></returns>
    public Pipeline SetComponentIntegrationId(string componentIntegrationId)
    {
        ComponentIntegrationId = componentIntegrationId;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="published"></param>
    /// <returns></returns>
    public Pipeline SetPublished(bool published)
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
    public Pipeline AddApplicationPipelineExecutedRecord(uint nextBuildNumber,string imageVersion)
    {
        var applicationPipelineExecutedRecord = new PipelineHistory(this.Id, PipelineBuildStateEnum.Running, this.PipelineScript, nextBuildNumber, imageVersion);
        PipelineHistories.Add(applicationPipelineExecutedRecord);
        return this;
    }
    
    
    public (string BuildImage,string PipelineScript) GetPipelineScript(Application app)
    {
        var buildImage = "";
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
                             userRemoteConfigs: [[ url: ""{pipelinePullCodeStep?.Git}""]]
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
                        buildImage = $"{compilePublishStep.BuildImageName}:{compilePublishStep.Version}";
                        stringBuilder.Append($@"
                        container('build') {{
                        sh '''
                        {compilePublishStep.CompileScript}
                        '''
                        }}");
                        break;
                    case StepTypeEnum.BuildDockerImage:
                        var pipelineBuildImageStep = step.Content.Deserialize<PipelineBuildImageStepDto>(new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });
                        if (pipelineBuildImageStep is null)
                        {
                            break;
                        }
                        buildImage = $"{pipelineBuildImageStep.BuildImageName}:{pipelineBuildImageStep.Version}";

                        var dockerRegistry = new DockerRegistry()
                        {
                            Auths = new Dictionary<string, AuthDto>()
                        };
                        byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes($"{app}:{app}");
                        dockerRegistry.Auths.Add("", new AuthDto()
                        {
                            Auth= Convert.ToBase64String(toEncodeAsBytes)//"MTU4NTk1NTM3NUBxcS5jb206d3p3MDEyNi4u"
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
                               /kaniko/executor -f {pipelineBuildImageStep.DockerFileSrc} -c . --destination={app}/toyar/{app.AppId}:""${{BRANCH_NAME}}""""${{VERSION_NAME}}""  --insecure --skip-tls-verify -v=debug
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

        return (buildImage,stringBuilder.ToString());
    }
}