﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toyar.App.Dto.ValueObjects.PipelinesValueObjects;

namespace Toyar.App.Dto.PipelineTemplates
{
    public class PipelineTemplateBaseDto
    {
        /// <summary>
        /// 流水线集成Id
        /// </summary>
        public string ComponentIntegrationId { get; set; } = default!;

        /// <summary>
        /// CI Runner 镜像Id
        /// </summary>
        public string ContinuousIntegrationImageId { get; set; } = default!;

        /// <summary>
        /// 流水线Dsl
        /// </summary>
        public ICollection<StageDto>? PipelineScript { get;  set; }
    }
}