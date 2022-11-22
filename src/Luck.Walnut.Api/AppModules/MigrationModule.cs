using Luck.Framework.Infrastructure;
using Luck.Walnut.Domain.AggregateRoots.Environments;
using Luck.Walnut.Domain.AggregateRoots.Languages;
using Luck.Walnut.Domain.AggregateRoots.Projects;
using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Api.AppModules
{
    [DependsOn(
        typeof(EntityFrameworkCoreModule)
    )]
    public class MigrationModule : AppModule
    {
        public override void ApplicationInitialization(ApplicationContext context)
        {
            var moduleDbContext = context.ServiceProvider.GetService<WalnutDbContext>();
            if (moduleDbContext != null)
            {
                var isExsit = moduleDbContext.Database.EnsureCreated();
                if (isExsit)
                {
                    var project = GetProject();
                    moduleDbContext.Projects.Add(project);
                    var application = GetApplication(project);
                    moduleDbContext.Applications.Add(application);
                    moduleDbContext.AppEnvironments.Add(GetApplication_Env(application));
                    moduleDbContext.Languages.AddRange(GetLanguageList());
                    moduleDbContext.SaveChanges();
                }
            }
        }


        private static Project GetProject()
        {
            return new Project("test", "wang-***", ProjectStatusEnum.Actity, new DateOnly(2021, 11, 12), null, null);
        }

        private static Domain.AggregateRoots.Applications.Application GetApplication(Project project)
        {
            return new Domain.AggregateRoots.Applications.Application(
                project.Id, "luck.walnut", "A", "胡桃木", "sda", "luck.walnut", ApplicationStateEnum.NotOnline, "asdas", "asdasd", ApplicationLevelEnum.LevelOne);
        }

        private static AppEnvironment GetApplication_Env(Domain.AggregateRoots.Applications.Application application)
        {
            var appEnvironment = new AppEnvironment("localtest", application.AppId, "本地测试");
            appEnvironment.AddConfiguration("asdasda", "asdasdasdasdq234231", "asdasdasdasdas", false, "asdfasdasdas");
            return appEnvironment;
        }

        private static List<Language> GetLanguageList()
        {
            return new List<Language>()
            {
                new Language(".Net", LanguageTypeEnum.DotNet),
                new Language("Python", LanguageTypeEnum.Python),
                new Language("Java", LanguageTypeEnum.Java),
                new Language("Go", LanguageTypeEnum.Go),
                new Language("Node", LanguageTypeEnum.NodeJs),
            };
        }
    }
}