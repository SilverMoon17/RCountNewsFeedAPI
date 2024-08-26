using RCountNewsFeedAPI.Models;
using RCountNewsFeedAPI.Models.DTOs;

namespace RCountNewsFeedAPI.Mappers;

public static class CategoryMapper
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            CategoryName = category.CategoryName
        };
    }
    
    public static Category ToModel(this CategoryDto categoryDto)
    {
        return new Category
        {
            Id = categoryDto.Id,
            CategoryName = categoryDto.CategoryName
        };
    }
}