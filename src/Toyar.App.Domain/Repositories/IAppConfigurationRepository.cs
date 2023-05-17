using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Dto;
using Toyar.App.Dto.Environments;

namespace Toyar.App.Domain.Repositories;

/// <summary>
/// 
/// </summary>
public interface IAppConfigurationRepository:IEntityRepository<AppConfiguration,string>,IScopedDependency
{
    Task<IEnumerable<AppConfigurationOutputDto>> FindListAsync(PageBaseInputDto query);

}