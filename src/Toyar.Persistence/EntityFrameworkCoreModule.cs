using Luck.EntityFrameworkCore;
using Luck.EntityFrameworkCore.DbContextDrivenProvides;
using Microsoft.Extensions.DependencyInjection;

namespace Toyar.Persistence
{
    public class EntityFrameworkCoreModule : EntityFrameworkCoreBaseModule
    {
        protected override void AddDbContextWithUnitOfWork(IServiceCollection services)
        {
            services.AddLuckDbContext<ToyarDbContext>(x =>
            {
                x.ConnectionString = "User ID=postgres;Password=wzw0126..;Host=192.168.31.30;Port=5432;Database=toyar";
                x.Type = DataBaseType.PostgreSQL;
            });
        }

        protected override void AddDbDriven(IServiceCollection service)
        {
            service.AddPostgreSQLDriven();
        }
    }
}
