using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Issues;

namespace Luck.Walnut.Query.Issues;

public interface IIssueQueryService:IScopedDependency
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IssueOutputDto?> GetIssueAsync(string id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PageBaseResult<IssueOutputDto>> GetIssueListAsync(IssueQueryDto input);

}