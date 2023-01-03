using Luck.EntityFrameworkCore.DbContexts;
using Luck.EntityFrameworkCore.Repositories;
using Luck.Walnut.Domain.AggregateRoots.Environments;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.BuildImages;
using Luck.Walnut.Dto.Environments;
using Microsoft.EntityFrameworkCore;

namespace Luck.Walnut.Persistence.Repositories;

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