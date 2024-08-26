using RCountNewsFeedAPI.Models.DTOs;

namespace RCountNewsFeedAPI.Repositories.Interfaces;

public interface INewsRepository
{
    Task<NewsDto> CreateNewsAsync(CreateNewsRequestDto newsDto);
    Task<NewsDto> GetNewsByIdAsync(int newsId);
    Task<IEnumerable<NewsDto>> GetAllNewsAsync();
    Task<IEnumerable<NewsDto>> GetLatestNewsAsync(int count);
    Task<NewsDto> UpdateNews(UpdateNewsRequestDto updateNewsRequestDto);
    Task<bool> DeleteNews(int id);
}