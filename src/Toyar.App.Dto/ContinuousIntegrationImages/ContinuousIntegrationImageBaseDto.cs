﻿namespace Toyar.App.Dto.ContinuousIntegrationImages
{
    public class ContinuousIntegrationImageBaseDto
    {
        /// <summary>
        /// 镜像名
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// 镜像名称 
        /// </summary>
        public string BuildImageName { get; set; } = default!;

        /// <summary>
        /// 构建脚本
        /// </summary>
        public string CompileScript { get; set; } = default!;
    }
}