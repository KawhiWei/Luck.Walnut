using Luck.DDD.Domain.Exceptions;

namespace Toyar.App.Domain.AggregateRoots.Environments
{
    /// <summary>
    /// 环境
    /// </summary>
    public class ToyarEnvironment : FullAggregateRoot
    {

        public ToyarEnvironment(string name, string chinesName)
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
