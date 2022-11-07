using Luck.EntityFrameworkCore.UnitOfWorks;
using Luck.Framework.Exceptions;
using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.ApplicationPipelines;

namespace Luck.Walnut.Application.ApplicationPipelines;

public class ApplicationPipelineService : IApplicationPipelineService
{
    private readonly IApplicationPipelineRepository _applicationPipelineRepository;

    private readonly UnitOfWork _unitOfWork;

    public ApplicationPipelineService(IApplicationPipelineRepository applicationPipelineRepository, UnitOfWork unitOfWork)
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

        var applicationPipeline = new ApplicationPipeline(input.AppId, input.Name, input.PipelineStatus, pipelineScript, input.AppEnvironmentId, false);
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


    private async Task<ApplicationPipeline> GetApplicationPipelineByIdAsync(string id)
    {
        var applicationPipeline = await _applicationPipelineRepository.FindFirstOrDefaultByIdAsync(id);
        if (applicationPipeline is null)
            throw new BusinessException($"流水线不存在");
        return applicationPipeline;
    }
}