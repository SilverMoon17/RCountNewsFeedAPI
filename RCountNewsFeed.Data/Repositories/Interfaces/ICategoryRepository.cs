using RCountNewsFeed.API.Models.DTOs;
using RCountNewsFeed.API.Models;
using RCountNewsFeed.Models;
using RCountNewsFeed.Models.DTOs.Category;

namespace RCountNewsFeed.API.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task SaveAsync();
    Task<Category> AddAsync(Category category);
    Task<Category> GetCategoryByIdAsync(int categoryId);

    Task<IEnumerable<Category>> GetCategoriesAsync();

    Task DeleteCategoryAsync(Category category);
}