using Luck.Walnut.Dto.Issues;

namespace Luck.Walnut.Application.Issues;

public interface IIssueService:IScopedDependency
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task CreateIssueAsync(IssueInputDto input);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Task UpdateIssueAsync(string id,IssueInputDto input);
    
    Task DeleteIssueAsync(string id);
}