using Luck.Walnut.Dto.BuildImages;
using Luck.Walnut.Query.BuildImages;
using Microsoft.AspNetCore.Mvc;

namespace Luck.Walnut.Api.Controllers;

[ApiController]
[Route("api/build/images")]
public class BuildImageController : BaseController
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="buildImageVersionQueryService"></param>
    /// <param name="imageId"></param>
    /// <returns></returns>
    [HttpGet("{imageId}/version/list")]
    public async Task<List<BuildImageVersionOutputDto>> GetBuildImageVersionListAsync([FromServices] IBuildImageVersionQueryService buildImageVersionQueryService, string imageId)
    {
        return await buildImageVersionQueryService.FindListAsync(imageId);
    }
}