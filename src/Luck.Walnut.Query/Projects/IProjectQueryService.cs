using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Projects;

namespace Luck.Walnut.Query.Projects;

public interface IProjectQueryService:IScopedDependency
{

    Task<PageBaseResult<ProjectOutputDto>> FindListAsync(ProjectQueryDto queryDto);
}