using System.Text.Json.Serialization;

namespace Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects
{

    public class DeploymentPlugin
    {
        [JsonConstructor]//这个特性 可以写私有，标识你要用哪个构造函数
        public DeploymentPlugin(Strategy strategy)
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
