using System.Runtime.CompilerServices;
using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.AggregateRoots.Projects;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Projects;

namespace Luck.Walnut.Query.Projects;

public class ProjectQueryService : IProjectQueryService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectQueryService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<PageBaseResult<ProjectOutputDto>> FindListAsync(ProjectQueryDto queryDto)
    {
        var totalCount= await _projectRepository.FindAll().CountAsync();
        var data=await _projectRepository.FindProjectAsync(queryDto);
        return new PageBaseResult<ProjectOutputDto>(totalCount, new[] { new ProjectOutputDto() });
    }


}