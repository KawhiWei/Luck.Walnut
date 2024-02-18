namespace Toyar.Domain.AggregateRoots.Environments
{
    /// <summary>
    /// 环境
    /// </summary>
    public class Environment : FullAggregateRoot
    {

        public Environment(string name, string chinesName)
        {

            Name = name;
            ChinesName = chinesName;
        }
        /// <summary>
        /// 环境名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 环境中文名称
        /// </summary>
        public string ChinesName { get; private set; }

    }

}
