﻿
using Toyar.App.Domain.AggregateRoots.ValueObjects;

namespace Toyar.App.Domain.AggregateRoots.Templates
{
    public class PipelineTemplate : FullAggregateRoot
    {
        public PipelineTemplate(string templateName, string componentIntegrationId, string continuousIntegrationImageId, ICollection<Stage> pipelineScript)
        {
            TemplateName = templateName;
            ComponentIntegrationId = componentIntegrationId;
            ContinuousIntegrationImageId = continuousIntegrationImageId;
            PipelineScript = pipelineScript;
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string TemplateName { get; private set; }

        /// <summary>
        /// 流水线集成Id
        /// </summary>
        public string ComponentIntegrationId { get; private set; }

        /// <summary>
        /// CI Runner 镜像Id
        /// </summary>
        public string ContinuousIntegrationImageId { get; private set; }

        /// <summary>
        /// 流水线Dsl
        /// </summary>
        public ICollection<Stage> PipelineScript { get; private set; } = new HashSet<Stage>();

        public void Update(string templateName, string componentIntegrationId, string continuousIntegrationImageId, ICollection<Stage> pipelineScript)
        {
            TemplateName = templateName;
            ComponentIntegrationId = componentIntegrationId;
            ContinuousIntegrationImageId = continuousIntegrationImageId;
        }

        public void SetPipelineScript(ICollection<Stage> pipelineScript)
        {
            PipelineScript = pipelineScript;
        }
    }
}