namespace Toyar.Domain.AggregateRoots.Environments
{
    /// <summary>
    /// 环境
    /// </summary>
    public class ToyarEnvironment : FullAggregateRoot
    {
        public ToyarEnvironment(string name, string chinesName, string createUserName, string createUserId,
            string lastModificationUserName, string lastModificationUserId, bool isSystemDefault = false)
        {
            Name = name;
            ChinesName = chinesName;
            CreateUserName = createUserName;
            CreateUserId = createUserId;
            LastModificationUserName = lastModificationUserName;
            LastModificationUserId = lastModificationUserId;
            IsSystemDefault = isSystemDefault;
        }

        /// <summary>
        /// 环境名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 环境中文名称
        /// </summary>
        public string ChinesName { get; private set; }

        /// <summary>
        /// 是否系统默认
        /// </summary>
        public bool IsSystemDefault { get; private set; }

        /// <summary>
        /// 环境中文名称
        /// </summary>
        public string CreateUserName { get; private set; }

        /// <summary>
        /// 环境中文名称
        /// </summary>
        public string CreateUserId { get; private set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LastModificationUserName { get; private set; }

        /// <summary>
        /// 最后修改人Id
        /// </summary>
        public string LastModificationUserId { get; private set; }
    }
}