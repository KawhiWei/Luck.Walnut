using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.AggregateRoots.BuildImages;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.BuildImages;

namespace Luck.Walnut.Application.BuildImages
{

    public class BuildImagesService : IBuildImagesService
    {
        private readonly IBuildImageRepository _buildImageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BuildImagesService(IBuildImageRepository buildImageRepository, IUnitOfWork unitOfWork)
        {
            _buildImageRepository = buildImageRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 添加镜像
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task AddBuildImageAsync(BuildImagesInputDto input)
        {
            await CheckBuildImages(input.BuildImageName);

            var buildImage = new BuildImage(input.Name, input.BuildImageName, input.CompileScript);
            _buildImageRepository.Add(buildImage);
            await _unitOfWork.CommitAsync();
        }

        private async Task CheckBuildImages(string name)
        {
            var buildImage = await GetBuildImagesByName(name);
            if (buildImage is not null)
            {
                throw new BusinessException($"镜像已存在");
            }
        }

        private Task<BuildImage?> GetBuildImagesByName(string name) => _buildImageRepository.FindFirstByNameAsync(name);

        /// <summary>
        /// 删除镜像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteBuildImageAsync(string id)
        {
            var buildImage = await CheckBuildImagesById(id);
            _buildImageRepository.Remove(buildImage);
            await _unitOfWork.CommitAsync();
        }

        private async Task<BuildImage> CheckBuildImagesById(string id)
        {
            var buildImage = await GetBuildImagesById(id);
            if (buildImage is null)
            {
                throw new BusinessException($"镜像不存在");
            }

            return buildImage;
        }

        private Task<BuildImage> GetBuildImagesById(string id) => _buildImageRepository.FindFirstByIdAsync(id);

        /// <summary>
        /// 修改镜像
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateBuildImageAsync(string id, BuildImagesInputDto input)
        {
            var buildImage = await CheckBuildImagesById(id);
            buildImage.UpdateInfo(input.Name, input.BuildImageName, input.CompileScript);
            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// 添加版本镜像
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CareatBuildImageVersion(BuildImageVersionInputDto input)
        {
            var buildImage = await _buildImageRepository.FindFirstByIdAsync(input.BuildImageId);
            buildImage.AddBuildImageVersion(input.Version);
            await _unitOfWork.CommitAsync();
        }
    }
}
