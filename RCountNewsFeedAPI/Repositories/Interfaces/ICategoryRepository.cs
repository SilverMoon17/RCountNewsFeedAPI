using RCountNewsFeedAPI.Models;
using RCountNewsFeedAPI.Models.DTOs;

namespace RCountNewsFeedAPI.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
    Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
    Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    Task<CategoryDto> UpdateCategory(CategoryDto categoryDto);
    Task<bool> DeleteCategory(int id);
}