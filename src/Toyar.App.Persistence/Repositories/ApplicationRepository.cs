using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Toyar.App.Domain.AggregateRoots.Applications;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.Applications;


namespace Toyar.App.Persistence.Repositories;

public class ApplicationRepository : EfCoreAggregateRootRepository<Application, string>, IApplicationRepository
{
    private readonly IDictionary<string, Application> _applicationsForId;
    private readonly IDictionary<string, Application> _applicationsForAppId;

    public ApplicationRepository(ILuckDbContext dbContext) : base(dbContext)
    {
        _applicationsForId = new Dictionary<string, Application>();
        _applicationsForAppId = new Dictionary<string, Application>();
    }

    public async Task<Application?> FindFirstOrDefaultByIdAsync(string id)
    {
        if (_applicationsForId.ContainsKey(id))
        {
            return _applicationsForId[id];
        }

        var application = await FindAll(x => x.Id == id).FirstOrDefaultAsync();
        if (application is null)
            return null;
        _applicationsForId.Add(id, application);

        return application;
    }

    public async Task<Application?> FindFirstOrDefaultByAppIdAsync(string appId)
    {
        if (_applicationsForAppId.ContainsKey(appId))
        {
            return _applicationsForAppId[appId];
        }

        var application = await FindAll(x => x.AppId == appId).FirstOrDefaultAsync();
        if (application is null)
            return null;
        _applicationsForAppId.Add(appId, application);

        return application;
    }


    public async Task<ApplicationOutputDto> FindFirstOrDefaultOutputDtoByAppIdAsync(string appId)
    {
        var application = await FindAll(x => x.AppId == appId).FirstOrDefaultAsync();
        if (application is null)
            throw new BusinessException($"应用不存在");

        ApplicationOutputDto dto = new ApplicationOutputDto()
        {
            Id = application.Id,
            AppId = application.AppId,
            GitUrl = application.GitUrl,
        };
        return dto;
    }

    public async Task<(ApplicationOutputDto[] Data, int TotalCount)> GetApplicationPageListAsync(ApplicationQueryDto query)
    {
        var queryable = FindAll()
            .Select(application => new ApplicationOutputDto
            {
                Id = application.Id,
                AppId = application.AppId,
                GitUrl = application.GitUrl,
                Name = application.Name,
            })
            .WhereIf(x => x.AppId.Contains(query.AppId), !query.AppId.IsNullOrWhiteSpace())
            .OrderByDescending(x => x.Id);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list, totalCount);
    }
}