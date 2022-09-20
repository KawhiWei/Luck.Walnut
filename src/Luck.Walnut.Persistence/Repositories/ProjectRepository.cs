using Luck.EntityFrameworkCore.DbContexts;
using Luck.EntityFrameworkCore.Repositories;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.AggregateRoots.Projects;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Projects;
using Microsoft.EntityFrameworkCore;

namespace Luck.Walnut.Persistence.Repositories;

public class ProjectRepository : EfCoreAggregateRootRepository<Project, string>, IProjectRepository
{
    public ProjectRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Project?> FindFirstOrDefaultByIdAsync(string id) => base.FindAll(x => x.Id == id).FirstOrDefaultAsync();
    
    
    
    public Task<List<Project>> FindProjectAsync(PageBaseInputDto baseInputDto) => base.FindAll().OrderByDescending(x=>x.CreationTime)
        .ToPage(baseInputDto.PageIndex,baseInputDto.PageSize).ToListAsync();
}