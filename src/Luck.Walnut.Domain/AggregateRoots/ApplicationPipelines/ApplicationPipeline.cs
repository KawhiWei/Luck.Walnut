using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Luck.Framework.Extensions;
using Luck.Walnut.Domain.AggregateRoots.Applications;
using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto.ApplicationPipelines;
using Luck.Walnut.Dto.ComponentIntegrations;

namespace Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;

public class ApplicationPipeline : FullAggregateRoot
{

    public ApplicationPipeline()
    {

    }
    public ApplicationPipeline(string appId, string name, IList<Stage> pipelineScript, string appEnvironmentId, bool published, string componentIntegrationId)
    {
        AppId = appId;
        Name = name;
        PipelineScript = pipelineScript;
        AppEnvironmentId = appEnvironmentId;
        Published = published;
        ComponentIntegrationId = componentIntegrationId;
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
    public ICollection<Stage> PipelineScript { get; private set; }


    /// <summary>
    /// 
    /// </summary>
    public string AppEnvironmentId { get; private set; }

    /// <summary>
    /// Jenkins下一次Build的Id
    /// </summary>
    public uint NextBuildNumber { get; private set; } = default!;

    /// <summary>
    /// 是否发布
    /// </summary>
    public bool Published { get; private set; }

    /// <summary>
    /// 组件集成Id
    /// </summary>
    public string ComponentIntegrationId { get; private set; }

    /// <summary>
    /// 执行记录
    /// </summary>
    public ICollection<ApplicationPipelineExecutedRecord> ApplicationPipelineExecutedRecords { get; private set; } = new HashSet<ApplicationPipelineExecutedRecord>();

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
    /// <param name="componentIntegrationId"></param>
    /// <returns></returns>
    public ApplicationPipeline SetComponentIntegrationId(string componentIntegrationId)
    {
        ComponentIntegrationId = componentIntegrationId;
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
    /// <param name="nextBuildNumber"></param>
    /// <returns></returns>
    public ApplicationPipeline AddApplicationPipelineExecutedRecord(uint nextBuildNumber)
    {
        var applicationPipelineExecutedRecord = new ApplicationPipelineExecutedRecord(this.Id, PipelineBuildStateEnum.Running, this.PipelineScript, nextBuildNumber, $"{AppId}-{DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss")}-{nextBuildNumber}");
        ApplicationPipelineExecutedRecords.Add(applicationPipelineExecutedRecord);
        return this;
    }
    
    
    public (string BuildImage,string PipelineScript) GetPipelineScript(Application application)
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
                             $class: 'GitSCM', branches: [[name: ""{pipelinePullCodeStep?.Branch}""]],
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
                        dockerRegistry.Auths.Add("https://registry.cn-hangzhou.aliyuncs.com",new AuthDto()
                        {
                            Auth= "MTU4NTk1NTM3NUBxcS5jb206d3p3MDEyNi4u"
                        });
                        
                        var jsonStr = dockerRegistry.Serialize(new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                        
                        Console.WriteLine(jsonStr);
                        stringBuilder.Append($@"
                        container('docker') {{
                            sh '''#!/busybox/sh -e
                               echo '{jsonStr}' > /kaniko/.docker/config.json
                            '''
                            sh '''#!/busybox/sh 
                               /kaniko/executor -f {pipelineBuildImageStep.DockerFileSrc} -c . --destination=IMAGE_REPOSITORY_NAME:v$BUILD_NUMBER  --insecure --skip-tls-verify -v=debug
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