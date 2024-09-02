using Microsoft.EntityFrameworkCore;
using RCountNewsFeed.API.DbContexts;
using RCountNewsFeed.API.Models;
using RCountNewsFeed.API.Models.DTOs;
using RCountNewsFeed.API.Repositories.Interfaces;
using RCountNewsFeed.Models;
using RCountNewsFeed.Models.DTOs.News;

namespace RCountNewsFeed.API.Repositories;

public class NewsRepository : INewsRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public NewsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<News?> AddAsync(News? news)
    {
        await _dbContext.News.AddAsync(news);
        await _dbContext.SaveChangesAsync();
    
        return news;
    }
    
    public async Task<News?> GetNewsByIdAsync(int newsId)
    {
        return await _dbContext.News.Include(n => n.Category).FirstOrDefaultAsync(n => n.Id == newsId);
    }
    
    public async Task<IEnumerable<News>> GetAllNewsAsync()
    {
        return await _dbContext.News.Include(n => n.Category).ToListAsync();
    }
    
    public async Task<IEnumerable<News>> GetLatestNewsAsync(int count)
    {
        var newsList = await _dbContext.News.OrderByDescending(n => n.Created)
            .Take(count)
            .Include(n => n.Category)
            .ToListAsync();
    
        return newsList;
    }
    
    public async Task DeleteNewsAsync(News news)
    {
        _dbContext.News.Remove(news);
    
        await _dbContext.SaveChangesAsync();
    }
}