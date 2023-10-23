using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Dto.Environments;

namespace Toyar.App.Domain.Repositories;

public interface IToyarEnvironmentRepository : IAggregateRootRepository<ToyarEnvironment, string>, IScopedDependency
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ToyarEnvironment?> FirstOrDefaultByIdAsync(string id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<ToyarEnvironment?> FirstOrDefaultByNameAsync(string name);


    /// <summary>
    /// 分页查询环境列表
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<(ToyarEnvironment[] Data, int TotalCount)> GetPageListAsync(ToyarEnvironmentQueryDto query);
}
