using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.Applications
{
    /// <summary>
    /// 应用
    /// </summary>
    public class Application : FullAggregateRoot
    {
        public Application(string projectId, string englishName, string departmentName, string chineseName, string principal, string appId, ApplicationStateEnum applicationState, string developmentLanguage, string buildImageId,
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
            BuildImageId = buildImageId;
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
        public string BuildImageId { get; set; } = default!;

        /// <summary>
        /// 需求描述
        /// </summary>
        public string? Describe { get; private set; }

        public Application UpdateInfo(string projectId, string englishName, string departmentName, string chineseName, string linkMan, string appId, ApplicationStateEnum applicationState,
            ApplicationLevelEnum applicationLevel, string developmentLanguage, string buildImageId, string? describe, string? codeWarehouseAddress)
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
            BuildImageId = buildImageId;
            return this;
        }
    }
}