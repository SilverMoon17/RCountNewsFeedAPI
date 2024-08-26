using RCountNewsFeedAPI.Models;
using RCountNewsFeedAPI.Models.DTOs;

namespace RCountNewsFeedAPI.Mappers;

public static class NewsMapper
{
    public static NewsDto ToDto(this News news)
    {
        return new NewsDto
        {
            Id = news.Id,
            Header = news.Header,
            Text = news.Text,
            ImageUrl = news.ImageUrl,
            Category = news.Category,
            CreatedByUserId = news.CreatedByUserId,
            Created = news.Created,
            UpdatedByUserId = news.UpdatedByUserId,
            Updated = news.Updated
        };
    }
    
    public static News ToModel(this NewsDto newsDto)
    {
        return new News
        {
            Id = newsDto.Id,
            Header = newsDto.Header,
            Text = newsDto.Text,
            ImageUrl = newsDto.ImageUrl,
            Category = newsDto.Category,
            CreatedByUserId = newsDto.CreatedByUserId,
            Created = newsDto.Created,
            UpdatedByUserId = newsDto.UpdatedByUserId,
            Updated = newsDto.Updated
        };
    }
}