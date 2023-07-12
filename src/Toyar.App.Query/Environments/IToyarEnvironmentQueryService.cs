using Toyar.App.Dto;
using Toyar.App.Dto.Environments;

namespace Toyar.App.Query.Environments
{
    public interface IToyarEnvironmentQueryService : IScopedDependency
    {

        /// <summary>
        /// 环境分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<PageBaseResult<ToyarEnvironmentOutputDto>> GetEnvironmentPageListAsync(ToyarEnvironmentQueryDto query);


        Task<ToyarEnvironmentOutputDto> GetEnvironmentDetailForIdAsync(string id);

    }
}
