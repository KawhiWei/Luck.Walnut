using Toyar.App.Dto.Environments;

namespace Toyar.App.AppService.Environments
{
    public interface IToyarEnvironmentService : IScopedDependency
    {

        /// <summary>
        /// 添加环境
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateEnvironmentAsync(ToyarEnvironmentInputDto input);

        /// <summary>
        /// 删除环境
        /// </summary>
        /// <param name="environmentId"></param>
        /// <returns></returns>
        Task DeleteEnvironmentAsync(string environmentId);

    }
}
