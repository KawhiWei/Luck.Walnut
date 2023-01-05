using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.BuildImages;

namespace Luck.Walnut.Query.BuildImages
{
    public class BuildImageQueryService : IBuildImageQueryService
    {
        private readonly IBuildImageRepository _buildImageRepository;

        public BuildImageQueryService(IBuildImageRepository buildImageRepository) 
        {
            _buildImageRepository = buildImageRepository;
        }

        /// <summary>
        /// 查询全部镜像
        /// </summary>
        /// <returns></returns>
        public Task<List<BuildImagesOutputDto>> GetBuildImages()
        {
            var buildImages = _buildImageRepository.FindAll();
            return buildImages.Select(p => new BuildImagesOutputDto
            {
                Id = p.Id,
                CompileScript = p.CompileScript,
                BuildImageName = p.BuildImageName,
                Name = p.Name,
            }).ToListAsync();
        }

        /// <summary>
        /// 分页查询全部镜像
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<PageBaseResult<BuildImagesOutputDto>> GetBuildImagesPageList(BuildImagesQueryDto query)
        {
            var buildImages = await _buildImageRepository.GetBuildImagePageListAsync(query);

            return new PageBaseResult<BuildImagesOutputDto>(buildImages.TotalCount, buildImages.Data.ToArray());
        }
    }
}
