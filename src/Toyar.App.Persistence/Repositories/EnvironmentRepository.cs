using Luck.EntityFrameworkCore.DbContexts;
using Luck.EntityFrameworkCore.Repositories;
using Luck.Framework.Exceptions;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.Environments;
using Microsoft.EntityFrameworkCore;

namespace Toyar.App.Persistence.Repositories;

public class EnvironmentRepository: EfCoreAggregateRootRepository<AppEnvironment, string>, IEnvironmentRepository
{
    public EnvironmentRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }
    
    public  Task<AppEnvironment?> FirstOrDefaultByIdAsync(string id)
    {
        return FindAll(x=>x.Id== id)
            .Include(x=>x.Configurations).FirstOrDefaultAsync();
    }

    public Task<AppEnvironment?> FirstOrDefaultByEnvironmentNameAsync(string environmentName)
    {
        return  FindAll(x => x.EnvironmentName == environmentName).FirstOrDefaultAsync();
    }


    public Task<List<AppEnvironmentListOutputDto>> GetEnvironmentListForApplicationId(string appId)
    {
        return FindAll(x => x.AppId == appId).Select(o => new AppEnvironmentListOutputDto()
        {
            Id = o.Id,
            ApplicationId = o.AppId,
            EnvironmentName = o.EnvironmentName,
        }).ToListAsync();
    }
    
    public async Task<PageBaseResult<AppConfigurationOutputDto>> GetAppConfigurationPageAsync(
        string environmentId, PageBaseInputDto baseInputDto)
    {
        var data= await FindAll().Where(o => o.Id == environmentId)
            .Include(o => o.Configurations).SelectMany(o => o.Configurations).Select(a =>
                new AppConfigurationOutputDto
                {
                    Id = a.Id,
                    IsOpen = a.IsOpen,
                    IsPublish = a.IsPublish,
                    Key = a.Key,
                    Type = a.Type,
                    Value = a.Value,
                }).ToPage(baseInputDto.PageIndex, baseInputDto.PageSize).ToArrayAsync();
        var total = await FindAll().Where(o => o.Id == environmentId)
            .Include(o => o.Configurations).SelectMany(o => o.Configurations).CountAsync();
        return new PageBaseResult<AppConfigurationOutputDto>(total,data);
    }
}