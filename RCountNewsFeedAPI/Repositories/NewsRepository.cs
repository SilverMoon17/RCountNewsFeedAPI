using Microsoft.EntityFrameworkCore;
using RCountNewsFeedAPI.DbContexts;
using RCountNewsFeedAPI.Mappers;
using RCountNewsFeedAPI.Models;
using RCountNewsFeedAPI.Models.DTOs;
using RCountNewsFeedAPI.Repositories.Interfaces;

namespace RCountNewsFeedAPI.Repositories;

public class NewsRepository : INewsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public NewsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<NewsDto> CreateNewsAsync(CreateNewsRequestDto createNewsDto)
    {
        var category = await _dbContext.Categories.FindAsync(createNewsDto.CategoryId);

        if (category is null)
            throw new ArgumentException($"Category with Id {createNewsDto.CategoryId} does not exist.", nameof(createNewsDto.CategoryId));

        var newsModel = new News
        {
            Header = createNewsDto.Header,
            Text = createNewsDto.Text,
            ImageUrl = createNewsDto.ImageUrl,
            Category = category,
            CreatedByUserId = createNewsDto.CreatedByUserId,
            UpdatedByUserId = createNewsDto.UpdatedByUserId
        };

        await _dbContext.News.AddAsync(newsModel);
        await _dbContext.SaveChangesAsync();

        return newsModel.ToDto();
    }

    public async Task<NewsDto> GetNewsByIdAsync(int newsId)
    {
        var news = await _dbContext.News.Include(n => n.Category).FirstOrDefaultAsync(n => n.Id == newsId);
        return news?.ToDto();
    }

    public async Task<IEnumerable<NewsDto>> GetAllNewsAsync()
    {
        var newsList = await _dbContext.News.Include(n => n.Category).ToListAsync();

        return newsList.Select(n => n.ToDto());
    }

    public async Task<IEnumerable<NewsDto>> GetLatestNewsAsync(int count)
    {
        if (count < 1)
            throw new ArgumentException("Count can't be lower than 1");
        
        var newsList = await _dbContext.News.OrderByDescending(n => n.Created)
            .Take(count)
            .Include(n => n.Category)
            .ToListAsync();

        return newsList.Select(n => n.ToDto());
    }

    public async Task<NewsDto> UpdateNews(UpdateNewsRequestDto updateNewsRequestDto)
    {
        var news = await _dbContext.News.FindAsync(updateNewsRequestDto.Id);

        if (news is null)
            throw new ArgumentException($"News with Id {updateNewsRequestDto.Id} does not exist.", nameof(updateNewsRequestDto.Id));
        
        var category = await _dbContext.Categories.FindAsync(updateNewsRequestDto.CategoryId);
        
        if (category is null)
            throw new ArgumentException($"Category with Id {updateNewsRequestDto.CategoryId} does not exist.", nameof(updateNewsRequestDto.CategoryId));

        news.Category = category;
        news.Updated = DateTime.UtcNow;
        news.Header = updateNewsRequestDto.Header;
        news.Text = updateNewsRequestDto.Text;
        news.ImageUrl = updateNewsRequestDto.ImageUrl;
        news.UpdatedByUserId = updateNewsRequestDto.UpdatedByUserId;

        await _dbContext.SaveChangesAsync();

        return news.ToDto();
    }

    public async Task<bool> DeleteNews(int id)
    {
        var news = await _dbContext.News.FindAsync(id);

        if (news is null)
            return false;

        _dbContext.News.Remove(news);

        await _dbContext.SaveChangesAsync();

        return true;
    }
}