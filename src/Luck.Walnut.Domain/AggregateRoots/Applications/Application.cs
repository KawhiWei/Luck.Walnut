using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.Applications
{
    /// <summary>
    /// 应用
    /// </summary>
    public class Application : FullAggregateRoot
    {
        public Application( string projectId,string englishName, string departmentName, string chinessName, string principal, string appId, ApplicationStatusEnum applicationStatus)
        {
            ProjectId = projectId;
            EnglishName = englishName;
            DepartmentName = departmentName;
            ChinessName = chinessName;
            Principal = principal;
            AppId = appId;
            ApplicationStatus = applicationStatus;
            
        }

        /// <summary>
        /// 项目id
        /// </summary>
        /// <returns></returns>
        public  string ProjectId { get; private set; } 
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
        public string ChinessName { get; private set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Principal { get; private set; }

        /// <summary>
        /// 应用唯一标识
        /// </summary>
        public string AppId { get; private set; }

        /// <summary>
        /// 应用状态
        /// </summary>
        public ApplicationStatusEnum ApplicationStatus { get; private set; }

        public Application UpdateInfo(string projectId,string englishName, string departmentName, string chinessName, string linkMan, string appId, ApplicationStatusEnum applicationStatus)
        {
            ProjectId = projectId;
            EnglishName = englishName;
            DepartmentName = departmentName;
            ChinessName = chinessName;
            Principal = linkMan;
            AppId = appId;
            ApplicationStatus = applicationStatus;
            return this;
        }
    }
}
