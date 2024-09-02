using RCountNewsFeed.Models.DTOs.News;

namespace RCountNewsFeed.Core.Services.Interfaces;

public interface INewsService
{
    Task<NewsDto> CreateNewsAsync(CreateNewsRequestDto createNewsRequestDto);
    Task<IEnumerable<NewsDto>> GetAllNewsAsync();
    Task<NewsDto> GetNewsByIdAsync(int id);
    Task<IEnumerable<NewsDto>> GetLatestNewsAsync(int count);
    Task<NewsDto> UpdateNewsAsync(UpdateNewsRequestDto updateNewsRequestDto);
    Task DeleteNewsAsync(int id);
}