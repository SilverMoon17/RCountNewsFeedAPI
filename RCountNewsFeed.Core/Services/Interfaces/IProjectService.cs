using RCountNewsFeed.API.Models.DTOs;

namespace RCountNewsFeed.Core.Services.Interfaces;

public interface IProjectService
{
    Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto);
    Task<ProjectDto> GetProjectByIdAsync(int projectId);
    Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
    Task<ProjectDto> UpdateProjectAsync(ProjectDto projectDto);
    Task DeleteProjectAsync(int projectId);
}