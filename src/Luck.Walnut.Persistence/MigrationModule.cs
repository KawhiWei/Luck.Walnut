using Luck.Framework.Infrastructure;
using Luck.Walnut.Domain.AggregateRoots.Applications;
using Luck.Walnut.Domain.AggregateRoots.Environments;
using Luck.Walnut.Domain.AggregateRoots.Languages;
using Luck.Walnut.Domain.AggregateRoots.Projects;
using Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;
using Luck.Walnut.Domain.Shared.Enums;
using Microsoft.Extensions.DependencyInjection;
using Luck.Walnut.Domain.AggregateRoots.BuildImages;

namespace Luck.Walnut.Persistence
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
            if (moduleDbContext == null) return;
            var isExist = moduleDbContext.Database.EnsureCreated();
            if (!isExist) return;
            var project = GetProject();
            var buildImage = GetBuildImage();
            var componentIntegration = ComponentIntegration();
            var application = GetApplication(project, buildImage, componentIntegration);
                    
            moduleDbContext.Projects.Add(project);

            application.SetBuildImage(buildImage.Id,new Image(buildImage.BuildImageName, buildImage.CompileScript))
                .SetImageWarehouse(componentIntegration.Credential);

            moduleDbContext.Applications.Add(application);
            moduleDbContext.AppEnvironments.Add(GetApplication_Env(application));

            moduleDbContext.Languages.Add(GetLanguage("C#"));
            moduleDbContext.RunImages.Add(buildImage);
            moduleDbContext.ComponentIntegrations.Add(componentIntegration);

            moduleDbContext.SaveChanges();
        }


        private static Project GetProject()
        {
            return new Project("test", "wang-***", ProjectStatusEnum.Actity, new DateOnly(2021, 11, 12), null, null);
        }

        private static Domain.AggregateRoots.Applications.Application GetApplication(Project project,BuildImage buildImage, ComponentIntegration componentIntegration)
        {


            return new Domain.AggregateRoots.Applications.Application(
                project.Id, "toyar.core", "A",
                "拓源", "sda", "toyar.core",
                ApplicationStateEnum.NotOnline, ".Net",
                applicationLevel: ApplicationLevelEnum.LevelOne,
                "https://github.com/GeorGeWzw/Luck.Walnut.git", "asdas", componentIntegration.Id, buildImage.Id);
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

            var runImage = new BuildImage(".Net6", "registry.cn-hangzhou.aliyuncs.com/luck-net/aspnet-sdk", @"# 编译命令，注：当前已在代码根路径下 
                                dotnet restore  
                                dotnet publish -p:PublishSingleFile=true -r linux-musl-x64 --self-contained true -p:PublishTrimmed=True -p:TrimMode=Link -c Release -o /app/publish");
            runImage.AddRunImageVersion("6.0");
            return runImage;
        }
    }
}