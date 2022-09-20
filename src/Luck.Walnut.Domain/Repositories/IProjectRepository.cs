using Luck.Framework.Infrastructure.DependencyInjectionModule;
using Luck.Walnut.Domain.AggregateRoots.Projects;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Projects;

namespace Luck.Walnut.Domain.Repositories;

public interface IProjectRepository: IAggregateRootRepository<Project,string>,IScopedDependency
{

    Task<Project?> FindFirstOrDefaultByIdAsync(string id);


    Task<List<Project>> FindProjectAsync(PageBaseInputDto baseInputDto);

}