using Microsoft.EntityFrameworkCore;
using RCountNewsFeedAPI.DbContexts;
using RCountNewsFeedAPI.Mappers;
using RCountNewsFeedAPI.Models;
using RCountNewsFeedAPI.Models.DTOs;
using RCountNewsFeedAPI.Repositories.Interfaces;

namespace RCountNewsFeedAPI.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var category = new Category
        {
            CategoryName = categoryDto.CategoryName
        };

        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();

        categoryDto.Id = category.Id;
        
        return categoryDto;
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
    {
        var category = await _dbContext.Categories.FindAsync(categoryId);

        return category?.ToDto();
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _dbContext.Categories.ToListAsync();

        return categories.Select(c => c.ToDto());
    }

    public async Task<CategoryDto> UpdateCategory(CategoryDto categoryDto)
    {
        var category = await _dbContext.Categories.FindAsync(categoryDto.Id);

        if (category is null)
            return null;
        
        category.CategoryName = categoryDto.CategoryName;

        await _dbContext.SaveChangesAsync();

        return category.ToDto();
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var category = await _dbContext.Categories.FindAsync(id);

        if (category is null)
            return false;

        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}