namespace Toyar.App.Domain.AggregateRoots.Applications
{
    /// <summary>
    /// 应用
    /// </summary>

    public class Application : FullAggregateRoot
    {
        public Application(string projectId, string appId, string gitUrl)
        {
            ProjectId = projectId;
            AppId = appId;
            GitUrl = gitUrl;
        }


        /// <summary>
        /// 项目id
        /// </summary>
        /// <returns></returns>
        public string ProjectId { get; private set; }

        /// <summary>
        /// 应用唯一标识
        /// </summary>
        public string AppId { get; private set; }

        /// <summary>
        /// 代码仓库地址
        /// </summary>
        public string GitUrl { get; private set; }

    }
}