using Luck.Walnut.Application.BuildImages;
using Luck.Walnut.Dto;
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buildImagesService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task AddBuildImage([FromServices] IBuildImagesService buildImagesService, [FromBody] BuildImagesInputDto input) => buildImagesService.AddBuildImageAsync(input);

    /// <summary>
    /// É¾³ý¾µÏñ
    /// </summary>
    /// <param name="buildImagesService"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public Task DeleteBuildImage([FromServices] IBuildImagesService buildImagesService, string id) => buildImagesService.DeleteBuildImageAsync(id);

    /// <summary>
    /// ÐÞ¸Ä¾µÏñ
    /// </summary>
    /// <param name="buildImagesService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public Task UpdateBuildImage([FromServices] IBuildImagesService buildImagesService, string id, [FromBody] BuildImagesInputDto input) => buildImagesService.UpdateBuildImageAsync(id, input);

    /// <summary>
    /// ²éÑ¯ËùÓÐ¾µÏñ
    /// </summary>
    /// <param name="buildImageQueryService"></param>
    /// <returns></returns>
    [HttpGet]
    public Task<List<BuildImagesOutputDto>> GetBuildImages([FromServices] IBuildImageQueryService buildImageQueryService) => buildImageQueryService.GetBuildImages();

    /// <summary>
    /// ·ÖÒ³²éÑ¯¾µÏñ
    /// </summary>
    /// <param name="buildImageQueryService"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpPost("Page")]
    Task<PageBaseResult<BuildImagesOutputDto>> GetBuildImagesPageList([FromServices] IBuildImageQueryService buildImageQueryService, [FromBody] BuildImagesQueryDto query) => buildImageQueryService.GetBuildImagesPageList(query);

}