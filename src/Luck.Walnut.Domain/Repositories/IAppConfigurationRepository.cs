using Luck.Walnut.Domain.AggregateRoots.Environments;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Environments;

namespace Luck.Walnut.Domain.Repositories;

/// <summary>
/// 
/// </summary>
public interface IAppConfigurationRepository:IEntityRepository<AppConfiguration,string>,IScopedDependency
{
    Task<IEnumerable<AppConfigurationOutputDto>> FindListAsync(PageBaseInputDto query);

}