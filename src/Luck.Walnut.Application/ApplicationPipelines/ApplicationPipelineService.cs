using Luck.EntityFrameworkCore.UnitOfWorks;
using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.ApplicationPipelines;

namespace Luck.Walnut.Application.ApplicationPipelines;

public class ApplicationPipelineService : IApplicationPipelineService
{
    private readonly IApplicationPipelineRepository _applicationPipelineRepository;

    private readonly IUnitOfWork _unitOfWork;

    public ApplicationPipelineService(IApplicationPipelineRepository applicationPipelineRepository, IUnitOfWork unitOfWork)
    {
        _applicationPipelineRepository = applicationPipelineRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(ApplicationPipelineInputDto input)
    {
        var pipelineScript = input.PipelineScript.Select(stage =>
            {
                var stageList = stage.Steps.Select(step => new Step(step.Name, step.StepType, step.Content));
                return new Stage(stage.Name, stageList.ToList());
            }
        ).ToList();

        var applicationPipeline = new ApplicationPipeline(input.AppId, input.Name, input.PipelineState, pipelineScript, input.AppEnvironmentId, false);
        _applicationPipelineRepository.Add(applicationPipeline);
        await _unitOfWork.CommitAsync();
    }


    public async Task UpdateAsync(string id, ApplicationPipelineInputDto input)
    {
        var pipelineScript = input.PipelineScript.Select(stage =>
            {
                var stageList = stage.Steps.Select(step => new Step(step.Name, step.StepType, step.Content));
                return new Stage(stage.Name, stageList.ToList());
            }
        ).ToList();
        var applicationPipeline = await GetApplicationPipelineByIdAsync(id);

        applicationPipeline.SetPipelineScript(pipelineScript).SetPublished(false);
        _applicationPipelineRepository.Update(applicationPipeline);
        await _unitOfWork.CommitAsync();
    }

    /// <summary>
    /// 发布流水线
    /// </summary>
    /// <param name="id"></param>
    public async Task PublishAsync(string id)
    {
        var applicationPipeline = await GetApplicationPipelineByIdAsync(id);
        await _unitOfWork.CommitAsync();
    }

    /// <summary>
    /// 删除流水线
    /// </summary>
    /// <param name="id"></param>
    public async Task DeleteAsync(string id)
    {
        var applicationPipeline = await GetApplicationPipelineByIdAsync(id);
        _applicationPipelineRepository.Remove(applicationPipeline);
        await _unitOfWork.CommitAsync();
    }


    private async Task<ApplicationPipeline> GetApplicationPipelineByIdAsync(string id)
    {
        var applicationPipeline = await _applicationPipelineRepository.FindFirstOrDefaultByIdAsync(id);
        if (applicationPipeline is null)
            throw new BusinessException($"流水线不存在");
        return applicationPipeline;
    }
}