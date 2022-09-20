using System.Runtime.CompilerServices;
using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.AggregateRoots.Projects;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.Projects;

namespace Luck.Walnut.Application.Projects;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateProjectAsync(ProjectInputDto input)
    {
        var project = new Project(input.Name, input.Describe, input.ProjectPrincipal, input.ProjectStatus, input.PlanStartTime, input.PlanEndTime);
        _projectRepository.Add(project);
        await _unitOfWork.CommitAsync();
    }


    public async Task UpdateProjectAsync(string id, ProjectInputDto input)
    {
        var project = await FindProjectByIdAndCheckAsync(id);
        project.UpdateInfo(input.Name, input.Describe, input.ProjectPrincipal, input.ProjectStatus, input.PlanStartTime, input.PlanEndTime);
        _projectRepository.Update(project);
        await _unitOfWork.CommitAsync();
    }

    
    public async Task DeleteProjectAsync(string id)
    {
        var project = await FindProjectByIdAndCheckAsync(id);
        _projectRepository.Remove(project);
        await _unitOfWork.CommitAsync();
    }

    private async Task<Project> FindProjectByIdAndCheckAsync(string id)
    {
        var project = await _projectRepository.FindFirstOrDefaultByIdAsync(id);
        if (project is null)
            throw new BusinessException($"项目不存在");
        return project;
    }
}