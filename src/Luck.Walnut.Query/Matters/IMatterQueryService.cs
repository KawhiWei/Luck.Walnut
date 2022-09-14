using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Matters;

namespace Luck.Walnut.Query.Matters;

public interface IMatterQueryService:IScopedDependency
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<MatterOutputDto?> GetMatterAsync(string id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PageBaseResult<MatterOutputDto>> GetMatterListAsync(MatterQueryDto input);

}