using Microsoft.EntityFrameworkCore;
using RCountNewsFeed.API.DbContexts;
using RCountNewsFeed.API.Models;
using RCountNewsFeed.API.Models.DTOs;
using RCountNewsFeed.API.Repositories.Interfaces;
using RCountNewsFeed.Models;
using RCountNewsFeed.Models.DTOs.Category;

namespace RCountNewsFeed.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Category> AddAsync(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        
        return category;
    }

    public async Task<Category> GetCategoryByIdAsync(int categoryId)
    {
        var category = await _dbContext.Categories.FindAsync(categoryId);
    
        return category;
    }
    
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }
    
    public async Task DeleteCategoryAsync(Category category)
    {
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
    }
}