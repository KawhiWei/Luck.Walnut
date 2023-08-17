using Toyar.App.Dto;
using Toyar.App.Dto.WorkLoads;

namespace Toyar.App.Query.WorkLoads;

public interface IWorkLoadQueryService : IScopedDependency
{
    Task<WorkLoadOutputDto> GetWorkLoadForIdAsync(string id);


    Task<PageBaseResult<WorkLoadOutputDto>> GetWorkLoadPageListAsync(string appId, WorkLoadQueryDto query);
}
