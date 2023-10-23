using System.Text.Json.Serialization;

namespace Toyar.App.Domain.AggregateRoots.ValueObjects.WorkLoadValueObjects
{

    public class WorkLoadPlugin
    {
        [JsonConstructor]//这个特性 可以写私有，标识你要用哪个构造函数
        public WorkLoadPlugin(Strategy strategy)
        {
            Strategy = strategy;
        }

        /// <summary>
        /// 
        /// </summary>
        public Strategy Strategy { get; private set; }


        public void SetStrategy(Strategy strategy)
        {
            Strategy = strategy;
        }
    }
}
