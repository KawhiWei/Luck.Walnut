using Luck.EntityFrameworkCore.DbContexts;
using Luck.EntityFrameworkCore.Repositories;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.ContinuousIntegrationImages;
using Toyar.App.Dto.Environments;
using Microsoft.EntityFrameworkCore;

namespace Toyar.App.Persistence.Repositories;

public class AppConfigurationRepository : EfCoreEntityRepository<AppConfiguration, string>, IAppConfigurationRepository
{
    public AppConfigurationRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<AppConfigurationOutputDto>> FindListAsync(PageBaseInputDto query)
    {
        return await FindAll().OrderByDescending(x => x.CreationTime)
            .Select(x => new AppConfigurationOutputDto
            {
                Id = x.Id,
                Key = x.Id,
                Value = x.Value,
                Type = x.Type,
                IsOpen = x.IsOpen,
                Group = x.Group,
                IsPublish = x.IsPublish,
            }).ToPage(query.PageIndex, query.PageSize).ToListAsync();
    }
}