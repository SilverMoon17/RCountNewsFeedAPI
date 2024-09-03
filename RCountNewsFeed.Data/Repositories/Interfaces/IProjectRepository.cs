using RCountNewsFeed.Models;

namespace RCountNewsFeed.API.Repositories.Interfaces;

public interface IProjectRepository
{
    Task SaveAsync();
    Task<Project> AddAsync(Project project);
    Task<Project> GetProjectByIdAsync(int projectId);

    Task<IEnumerable<Project>> GetProjectsAsync();

    Task DeleteProjectAsync(Project project);
}