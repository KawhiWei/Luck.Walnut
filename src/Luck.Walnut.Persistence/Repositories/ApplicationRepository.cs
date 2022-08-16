using Luck.EntityFrameworkCore.DbContexts;
using Luck.EntityFrameworkCore.Repositories;
using Luck.Walnut.Domain.AggregateRoots.Applications;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Applications;
using Microsoft.EntityFrameworkCore;

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
        if(_applicationsForId.ContainsKey(id))
        {
            return _applicationsForId[id];
        }

        var application= await FindAll(x => x.Id == id).FirstOrDefaultAsync();
        if(application is null)
            return null;
        _applicationsForId.Add(id, application);

        return application;
    }

    public async Task<Application?> FindFirstOrDefaultByAppIdAsync(string appId)
    {
        if(_applicationsForAppId.ContainsKey(appId))
        {
            return _applicationsForAppId[appId];
        }    

        var application= await FindAll(x => x.AppId == appId).FirstOrDefaultAsync();
        if (application is null)
            return null;
        _applicationsForAppId.Add(appId, application);

        return application;
    }

    
    public async Task<IEnumerable<ApplicationOutputDto>> FindListAsync(PageInput input)
    {
        return await  FindAll()
            .Select(c => new ApplicationOutputDto
            {
                Id = c.Id,
                AppId = c.AppId,
                Status = c.Status,
                EnglishName = c.EnglishName,
                ChinessName = c.ChinessName,
                DepartmentName = c.DepartmentName,
                LinkMan = c.LinkMan,
            }).OrderByDescending(x=>x.Id).ToPage(input.PageIndex,input.PageSize).ToArrayAsync();
    }
}