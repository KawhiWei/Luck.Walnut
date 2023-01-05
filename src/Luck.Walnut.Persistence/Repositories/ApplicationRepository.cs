using Luck.EntityFrameworkCore.DbContexts;
using Luck.EntityFrameworkCore.Repositories;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Luck.Walnut.Domain.AggregateRoots.Applications;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.Applications;

namespace Luck.Walnut.Persistence.Repositories;

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
            ApplicationState = application.ApplicationState,
            EnglishName = application.EnglishName,
            ChineseName = application.ChineseName,
            DepartmentName = application.DepartmentName,
            Principal = application.Principal,
            ProjectId = application.ProjectId,
            Describe = application.Describe,
            ApplicationLevel = application.ApplicationLevel,
            CodeWarehouseAddress = application.CodeWarehouseAddress,
            CompileScript = application.BuildImage.CompileScript,
            BuildImageName = application.BuildImage.BuildImageName,
            BuildImageId= application.BuildImageId,
        };
        return dto;
    }

    public async Task<(ApplicationOutputDto[] Data, int TotalCount)> GetApplicationPageListAsync(ApplicationQueryDto query)
    {
        var queryable = FindAll()
            .Select(c => new ApplicationOutputDto
            {
                Id = c.Id,
                AppId = c.AppId,
                ApplicationState = c.ApplicationState,
                EnglishName = c.EnglishName,
                ChineseName = c.ChineseName,
                DepartmentName = c.DepartmentName,
                Principal = c.Principal,
                ProjectId = c.ProjectId,
                ApplicationLevel = c.ApplicationLevel,
                DevelopmentLanguage = c.DevelopmentLanguage,
            })
            .WhereIf(x => x.ProjectId == query.ProjectId, !query.ProjectId.IsNullOrWhiteSpace())
            .WhereIf(x => x.EnglishName.Contains(query.EnglishName), !query.EnglishName.IsNullOrWhiteSpace())
            .WhereIf(x => x.ChineseName.Contains(query.ChineseName), !query.ChineseName.IsNullOrWhiteSpace())
            .WhereIf(x => x.Principal.Contains(query.Principal), !query.Principal.IsNullOrWhiteSpace())
            .WhereIf(x => x.AppId.Contains(query.AppId), !query.AppId.IsNullOrWhiteSpace())
            .WhereIf(x => x.ApplicationState == query.ApplicationState, query.ApplicationState.HasValue)
            .OrderByDescending(x => x.Id);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list, totalCount);
    }
}