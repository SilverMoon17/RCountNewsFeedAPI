using Microsoft.EntityFrameworkCore;
using RCountNewsFeed.API.DbContexts;
using RCountNewsFeed.API.Repositories.Interfaces;
using RCountNewsFeed.Models;

namespace RCountNewsFeed.Data.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProjectRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Project> AddAsync(Project project)
    {
        await _dbContext.Projects.AddAsync(project);
        await _dbContext.SaveChangesAsync();
        
        return project;
    }

    public async Task<Project> GetProjectByIdAsync(int projectId)
    {
        return await _dbContext.Projects.FindAsync(projectId);
    }

    public async Task<IEnumerable<Project>> GetProjectsAsync()
    {
        return await _dbContext.Projects.ToListAsync();
    }

    public async Task DeleteProjectAsync(Project project)
    {
        _dbContext.Projects.Remove(project);
        await _dbContext.SaveChangesAsync();
    }
}