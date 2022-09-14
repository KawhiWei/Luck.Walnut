using Luck.Walnut.Dto.Matters;

namespace Luck.Walnut.Application.Matters;

public interface IMatterService:IScopedDependency
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task CreateMatterAsync(MatterInputDto input);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    Task UpdateMatterAsync(string id,MatterInputDto input);
    
    Task DeleteMatterAsync(string id);
}