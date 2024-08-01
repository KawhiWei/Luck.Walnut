using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.UnitOfWorks;
using Toyar.Domain.AggregateRoots.ToyarEnvironments;
using Toyar.Domain.Repositories;

namespace Toyar.Persistence.Repositories;

public class ToyarEnvironmentRepository : EfCoreAggregateRootRepository<ToyarEnvironment, string>,
    IToyarEnvironmentRepository
{
    public ToyarEnvironmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public Task<ToyarEnvironment?> FindToyarEnvironmentByEnglishName(string englishName) => FindAll()
        .FirstOrDefaultAsync(x => x.EnglishName == englishName);

    public Task<ToyarEnvironment?> FindToyarEnvironmentDetailByIdAsync(string id) => FindAll()
        .FirstOrDefaultAsync(x => x.Id == id);
}