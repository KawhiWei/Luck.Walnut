using Toyar.Domain.AggregateRoots.ToyarBaseComponents;

namespace Toyar.Domain.Repositories;

public interface IToyarBaseComponentRepository : IAggregateRootRepository<ToyarBaseComponent, string>, IScopedDependency
{
    /// <summary>
    /// 根据id查询组件
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ToyarBaseComponent?> FindToyarBaseComponentByIdAsync(string id);
}