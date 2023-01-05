using System.Text.Json.Serialization;
using Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;
using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.Applications
{
    /// <summary>
    /// 应用
    /// </summary>
    public class Application : FullAggregateRoot
    {
        public Application(string projectId, string englishName, string departmentName, string chineseName, string principal, 
            string appId, ApplicationStateEnum applicationState, string developmentLanguage,
            ApplicationLevelEnum applicationLevel, string? codeWarehouseAddress, string? describe)
        {
            ProjectId = projectId;
            EnglishName = englishName;
            DepartmentName = departmentName;
            ChineseName = chineseName;
            Principal = principal;
            AppId = appId;
            ApplicationState = applicationState;
            Describe = describe;
            CodeWarehouseAddress = codeWarehouseAddress;
            ApplicationLevel = applicationLevel;
            DevelopmentLanguage = developmentLanguage;
        }

        /// <summary>
        /// 项目id
        /// </summary>
        /// <returns></returns>
        public string ProjectId { get; private set; }

        /// <summary>
        /// 应用服务名称
        /// </summary>
        public string EnglishName { get; private set; }

        /// <summary>
        /// 应用所属部门
        /// </summary>
        public string DepartmentName { get; private set; }

        /// <summary>
        /// 应用中文名称
        /// </summary>
        public string ChineseName { get; private set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Principal { get; private set; }

        /// <summary>
        /// 应用唯一标识
        /// </summary>
        public string AppId { get; private set; }

        /// <summary>
        /// 应用保障等级
        /// </summary>
        public ApplicationLevelEnum ApplicationLevel { get; private set; }

        /// <summary>
        /// 代码仓库地址
        /// </summary>
        public string? CodeWarehouseAddress { get; private set; }

        /// <summary>
        /// 应用状态
        /// </summary>
        public ApplicationStateEnum ApplicationState { get; private set; }

        /// <summary>
        /// 开发语言
        /// </summary>
        public string DevelopmentLanguage { get; private set; }
        
        /// <summary>
        /// 运行平台
        /// </summary>
        public Credential ImageWarehouse { get; private set; } = default!;

        /// <summary>
        /// 
        /// </summary>
        public BuildImage BuildImage { get; private set; } = default!;
        /// <summary>
        /// 需求描述
        /// </summary>
        public string? Describe { get; private set; }

        public Application UpdateInfo(string projectId, string englishName, string departmentName, string chineseName, string linkMan, string appId, ApplicationStateEnum applicationState,
            ApplicationLevelEnum applicationLevel, string developmentLanguage,string? describe, string? codeWarehouseAddress
            )
        {
            ProjectId = projectId;
            EnglishName = englishName;
            DepartmentName = departmentName;
            ChineseName = chineseName;
            Principal = linkMan;
            AppId = appId;
            ApplicationState = applicationState;
            ApplicationLevel = applicationLevel;
            Describe = describe;
            CodeWarehouseAddress = codeWarehouseAddress;
            DevelopmentLanguage = developmentLanguage;
            return this;
        }

        public Application SetImageWarehouse(Credential imageWarehouse)
        {
            ImageWarehouse = imageWarehouse;
            return this;
        }
        public Application SetImageWarehouse(BuildImage image)
        {
            BuildImage = image;
            return this;
        }
    }

    /// <summary>
    /// 构建镜像信息
    /// </summary>
    public class BuildImage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="buildImageName"></param>
        /// <param name="compileScript"></param>
        /// <param name="version"></param>
        [JsonConstructor]//这个特性 可以写私有，标识你要用哪个构造函数
        public BuildImage(string name, string buildImageName, string compileScript, string version)
        {
            Name = name;
            BuildImageName = buildImageName;
            CompileScript = compileScript;
            Version = version;
        }

        /// <summary>
        /// 镜像名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 镜像地址
        /// </summary>
        public string BuildImageName { get; private set; }
    
        /// <summary>
        /// 镜像地址
        /// </summary>
        public string CompileScript { get; private set; }
        
        
        /// <summary>
        /// 镜像名称
        /// </summary>
        public string Version { get; private set; }
    }
}