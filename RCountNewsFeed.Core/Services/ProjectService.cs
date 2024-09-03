using AutoMapper;
using RCountNewsFeed.API.Models.DTOs;
using RCountNewsFeed.API.Repositories.Interfaces;
using RCountNewsFeed.Core.Services.Interfaces;
using RCountNewsFeed.Models;

namespace RCountNewsFeed.Core.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }


    public async Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto)
    {
        var project = _mapper.Map<Project>(projectDto);
        
        project = await _projectRepository.AddAsync(project);
        
        return _mapper.Map<ProjectDto>(project);
    }

    public async Task<ProjectDto> GetProjectByIdAsync(int projectId)
    {
        var project = await _projectRepository.GetProjectByIdAsync(projectId);

        if (project is null)
        {
            throw new ArgumentException($"Project with id: {projectId} not found");
        }
        
        return _mapper.Map<ProjectDto>(project);
    }

    public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
    {
        return _mapper.Map<IEnumerable<ProjectDto>>(await _projectRepository.GetProjectsAsync());
    }

    public async Task<ProjectDto> UpdateProjectAsync(ProjectDto projectDto)
    {
        var project = await _projectRepository.GetProjectByIdAsync(projectDto.Id);

        if (project is null)
        {
            throw new ArgumentException($"Project with id: {projectDto.Id} not found");
        }
        
        project = _mapper.Map(projectDto, project);
        
        await _projectRepository.SaveAsync();
        
        return _mapper.Map<ProjectDto>(project);
    }

    public async Task DeleteProjectAsync(int projectId)
    {
        var project = await _projectRepository.GetProjectByIdAsync(projectId);

        if (project is null)
        {
            throw new ArgumentException($"Project with id: {projectId} not found");
        }
        
        await _projectRepository.DeleteProjectAsync(project);
    }
}