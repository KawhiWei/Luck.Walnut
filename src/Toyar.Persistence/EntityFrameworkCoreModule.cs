using Luck.EntityFrameworkCore;
using Luck.EntityFrameworkCore.DbContextDrivenProvides;
using Luck.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.DependencyInjection;

namespace Toyar.Persistence
{
    public class EntityFrameworkCoreModule : EntityFrameworkCoreBaseModule
    {
        protected override void AddDbContextWithUnitOfWork(IServiceCollection services)
        {
            services.AddLuckDbContext<ToyarDbContext>(x =>
            {
                x.ConnectionString = "User ID=postgres;Password=wzw0126..;Host=localhost;Port=5432;Database=toyar";
                x.Type = DataBaseType.PostgreSql;
            });
        }

        protected override void AddDbDriven(IServiceCollection service)
        {
            service.AddPostgreSQLDriven();
        }
    }
}
