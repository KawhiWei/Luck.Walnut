using System.Runtime.CompilerServices;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.AggregateRoots.Projects;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Domain.Shared.Enums;
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

    public async Task<PageBaseResult<ProjectOutputDto>> GetProjectPageListAsync(ProjectQueryDto queryDto)
    {
        var result = await _projectRepository.GetProjectPageListAsync(queryDto);
        return result;
    }


    public IEnumerable<KeyValuePair<string, string>> GetProjectEnumList()
    {
        var type = typeof(ProjectStatusEnum);
        var names = Enum.GetNames(type);
        Dictionary<string, string> dictionary = new Dictionary<string, string>(names.Length);
        foreach (var name in names)
        {
            var member = type.GetMember(name).FirstOrDefault();
            if (member is null)
                dictionary.Add(name.ToString(), "");
            else
                dictionary.Add(name.ToString(), member.ToDescription());
        }
        return dictionary.ToArray();
    }
}