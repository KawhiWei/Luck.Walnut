using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;

namespace Luck.Walnut.Adapter.JenkinsAdapter;

public static class JenkinsPipeLineTemplates
{
    public const string PipelineXml = @"
<flow-definition plugin=""workflow-job@2.32"">
    <actions>
        <io.jenkins.blueocean.service.embedded.BlueOceanUrlAction_-DoNotShowPersistedBlueOceanUrlActions plugin=""blueocean-rest-impl@1.16.0""/>
            <org.jenkinsci.plugins.pipeline.modeldefinition.actions.DeclarativeJobPropertyTrackerAction plugin=""pipeline-model-definition@1.3.8"">
            <jobProperties/>
        <triggers/>
        <parameters/>
        <options/>
        </org.jenkinsci.plugins.pipeline.modeldefinition.actions.DeclarativeJobPropertyTrackerAction>
        <org.jenkinsci.plugins.pipeline.modeldefinition.actions.DeclarativeJobAction plugin=""pipeline-model-definition@1.3.8""/>
    </actions>
    <description>SGR PaaS jenkins pipeline</description>
    <keepDependencies>false</keepDependencies>
    <properties>
        <jenkins.model.BuildDiscarderProperty>
            <strategy class=""hudson.tasks.LogRotator"">
                <daysToKeep>-1</daysToKeep>
                <numToKeep>10</numToKeep>
                <artifactDaysToKeep>-1</artifactDaysToKeep>
                <artifactNumToKeep>-1</artifactNumToKeep>
            </strategy>
        </jenkins.model.BuildDiscarderProperty>
    </properties>
    <definition class=""org.jenkinsci.plugins.workflow.cps.CpsFlowDefinition"" plugin=""workflow-cps@2.69"">
        <script>
            @Pipeline
        </script>
        <sandbox>false</sandbox>
    </definition>
    <triggers/>
    <disabled>false</disabled>
</flow-definition>
        ";

    public const string PipelineTemplate = @"
pipeline {
    agent {
        kubernetes {
            defaultContainer 'jnlp'
            yaml """"""
apiVersion: v1
kind: Pod
metadata:
namespace: luck-infrastructure
spec:
  containers: @Containers
    """"""          
        }
    }
";
}

// public const string PipelineTemplate = @"
// pipeline {
//     agent {
//         kubernetes {
//             defaultContainer 'jnlp'
//             yaml """"""
// apiVersion: v1
// kind: Pod
// metadata:
// namespace: luck-infrastructure
// spec:
//   containers:
//   - name: jnlp
//     image: registry.cn-hangzhou.aliyuncs.com/luck-walunt/inbound-agent:4.10-3-v1
//     workingDir: /home/jenkins/agent
//     command:
//     args:
//     tty: true
//   - name: docker
//     image: registry.cn-hangzhou.aliyuncs.com/luck-walunt/kaniko-executor:v1.9.0-debug-v1
//     workingDir: /home/jenkins/agent
//     command:
//     - cat
//     args:
//     tty: true
//     """"""          
//         }
//     }
// ";
// }
