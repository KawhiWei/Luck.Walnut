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

    /// <summary>
    /// 根据Id获取一个项目
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Project?> FindFirstOrDefaultByIdAsync(string id) => base.FindAll(x => x.Id == id).FirstOrDefaultAsync();


    /// <summary>
    /// 获取项目分页数据
    /// </summary>
    /// <param name="baseInputDto"></param>
    /// <returns></returns>
    public async Task<PageBaseResult<ProjectOutputDto>> GetProjectPageListAsync(PageBaseInputDto baseInputDto)
    {
        var data =
            await FindAll().OrderByDescending(x => x.CreationTime)
                .ToPage(baseInputDto.PageIndex,baseInputDto.PageSize)
                .Select(x => new ProjectOutputDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Describe = x.Describe,
                    ProjectPrincipal = x.ProjectPrincipal,
                    ProjectStatus = x.ProjectStatus,
                    PlanStartTime = x.PlanStartTime,
                    PlanEndTime = x.PlanEndTime,
                }).ToArrayAsync();
        var totalCount = await FindAll().CountAsync();
        return new PageBaseResult<ProjectOutputDto>(totalCount, data);
    }
}