using RCountNewsFeed.API.Models.DTOs;
using RCountNewsFeed.Models;
using RCountNewsFeed.Models.DTOs.News;

namespace RCountNewsFeed.API.Repositories.Interfaces;

public interface INewsRepository
{
    Task<News?> AddAsync(News? news);

    Task<IEnumerable<News>> GetAllNewsAsync();

    Task<News?> GetNewsByIdAsync(int newsId);

    Task<IEnumerable<News>> GetLatestNewsAsync(int count);

    Task SaveAsync();
    Task DeleteNewsAsync(News news);
}