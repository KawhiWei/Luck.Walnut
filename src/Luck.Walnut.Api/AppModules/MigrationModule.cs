using Luck.Framework.Infrastructure;
using Luck.Walnut.Domain.AggregateRoots.Applications;
using Luck.Walnut.Domain.AggregateRoots.Environments;
using Luck.Walnut.Domain.AggregateRoots.Languages;
using Luck.Walnut.Domain.AggregateRoots.Projects;
using Luck.Walnut.Domain.AggregateRoots.BuildImages;
using Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;
using Luck.Walnut.Domain.Shared.Enums;
using BuildImage = Luck.Walnut.Domain.AggregateRoots.BuildImages.BuildImage;

namespace Luck.Walnut.Api.AppModules
{
    [DependsOn(
        typeof(EntityFrameworkCoreModule)
    )]
    public class MigrationModule : AppModule
    {
        //P过SQL删除    drop schema "luck.walnut" cascade;
        public override void ApplicationInitialization(ApplicationContext context)
        {
            var moduleDbContext = context.ServiceProvider.GetService<WalnutDbContext>();
            if (moduleDbContext != null)
            {
                var isExist = moduleDbContext.Database.EnsureCreated();
                if (isExist)
                {
                    var project = GetProject();
                    var buildImage = GetBuildImage();
                    var application = GetApplication(project);
                    moduleDbContext.Projects.Add(project);

                    application.SetImageWarehouse(new Domain.AggregateRoots.Applications.BuildImage(buildImage.Name, buildImage
                            .BuildImageName, buildImage.CompileScript, buildImage.Id))
                        .SetImageWarehouse(new Credential(componentLinkUrl: "https://jenkins.sukt.store", userName: "kawhi", passWord: "", token: "119dc867c3746ca39414387a1de9583d31"));

                    moduleDbContext.Applications.Add(application);
                    moduleDbContext.AppEnvironments.Add(GetApplication_Env(application));

                    moduleDbContext.Languages.Add(GetLanguage("C#"));
                    moduleDbContext.RunImages.Add(buildImage);
                    moduleDbContext.ComponentIntegrations.Add(ComponentIntegration());

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
                project.Id, "luck.walnut", "A",
                "胡桃木", "sda", "luck.walnut",
                ApplicationStateEnum.NotOnline, ".Net",
                applicationLevel: ApplicationLevelEnum.LevelOne,
                "https://github.com/GeorGeWzw/Luck.Framework.git", "asdas");
        }

        private static AppEnvironment GetApplication_Env(Domain.AggregateRoots.Applications.Application application)
        {
            var appEnvironment = new AppEnvironment("localtest", application.AppId, "本地测试");
            appEnvironment.AddConfiguration("asdasda", "asdasdasdasdq234231", "asdasdasdasdas", false, "asdfasdasdas");
            return appEnvironment;
        }

        private static Language GetLanguage(string name)
        {
            return new Language(name, LanguageTypeEnum.DotNet);
        }

        private static ComponentIntegration ComponentIntegration()
        {
            var credential = new Credential(componentLinkUrl: "https://jenkins.sukt.store", userName: "kawhi", passWord: "", token: "119dc867c3746ca39414387a1de9583d31");
            return new ComponentIntegration("Jenkins流水线引擎公网地址", ComponentTypeEnum.Jenkins, credential, ComponentCategoryEnum.PipeLine);
        }

        private static BuildImage GetBuildImage()
        {
            // 删除pg schema时报错
            // ERROR:  database "luck.walnut" is being accessed by other users
            //DETAIL:  There is 1 other session using the database.
            //使用以下命令解决
            //drop schema "luck.walnut" cascade;

            var runImage = new BuildImage(".Net6", "mcr.microsoft.com/dotnet/sdk", @"# 编译命令，注：当前已在代码根路径下 
                                dotnet restore  
                                dotnet publish -p:PublishSingleFile=true -r linux-musl-x64 --self-contained true -p:PublishTrimmed=True -p:TrimMode=Link -c Release -o /app/publish");
            runImage.AddRunImageVersion("6.0");
            return runImage;
        }
    }
}