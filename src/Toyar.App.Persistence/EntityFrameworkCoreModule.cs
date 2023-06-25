

using Luck.EntityFrameworkCore;
using Luck.EntityFrameworkCore.DbContextDrivenProvides;
using Microsoft.Extensions.DependencyInjection;

namespace Toyar.App.Persistence
{
    public class EntityFrameworkCoreModule : EntityFrameworkCoreBaseModule
    {
        protected override void AddDbContextWithUnitOfWork(IServiceCollection services)
        {
            services.AddLuckDbContext<ToyarDbContext>(x =>
            {
                x.ConnectionString = "User ID=postgres;Password=wzw0126..;Host=39.101.165.187;Port=8832;Database=toyar.app";
                x.Type = DataBaseType.PostgreSQL;
            });
        }

        protected override void AddDbDriven(IServiceCollection service)
        {
            service.AddPostgreSQLDriven();
        }
    }
}
