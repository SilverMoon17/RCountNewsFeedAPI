using RCountNewsFeed.Models.DTOs.Category;

namespace RCountNewsFeed.Core.Services.Interfaces;

public interface ICategoryService
{
    Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
    Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
    Task<IEnumerable<CategoryDto>> GetAllCategories();
    Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto);
    Task DeleteCategoryAsync(int categoryId);

}