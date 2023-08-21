using Toyar.App.Dto;
using Toyar.App.Dto.K8s.WorkLoads;

namespace Toyar.App.Query.K8s.WorkLoads;

public interface IWorkLoadQueryService : IScopedDependency
{
    Task<WorkLoadOutputDto> GetWorkLoadForIdAsync(string id);


    Task<PageBaseResult<WorkLoadOutputDto>> GetWorkLoadPageListAsync(string appId, WorkLoadQueryDto query);
}
