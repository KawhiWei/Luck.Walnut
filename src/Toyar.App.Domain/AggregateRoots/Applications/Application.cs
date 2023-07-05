﻿namespace Toyar.App.Domain.AggregateRoots.Applications
{
    /// <summary>
    /// 应用
    /// </summary>

    public class Application : FullAggregateRoot
    {
        public Application(string projectId, string name, string appId, string gitUrl)
        {
            ProjectId = projectId;
            Name = name;
            AppId = appId;
            GitUrl = gitUrl;

        }


        /// <summary>
        /// 项目id
        /// </summary>
        /// <returns></returns>
        public string ProjectId { get; private set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 应用唯一标识
        /// </summary>
        public string AppId { get; private set; }

        /// <summary>
        /// 代码仓库地址
        /// </summary>
        public string GitUrl { get; private set; }

        /// <summary>
        /// 应用描述
        /// </summary>
        public string? Describe { get; private set; }

        /// <summary>
        /// 应用部署环境
        /// </summary>
        public ICollection<string> AppEnvironments = new HashSet<string>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="describe"></param>
        /// <returns></returns>
        public Application SetDescribe(string describe)
        {
            Describe = describe;
            return this;
        }


    }
}