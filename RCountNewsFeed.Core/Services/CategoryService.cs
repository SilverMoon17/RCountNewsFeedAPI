using AutoMapper;
using RCountNewsFeed.API.Repositories.Interfaces;
using RCountNewsFeed.Core.Services.Interfaces;
using RCountNewsFeed.Models;
using RCountNewsFeed.Models.DTOs.Category;

namespace RCountNewsFeed.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var category = new Category
        {
            CategoryName = categoryDto.CategoryName
        };

        await _categoryRepository.AddAsync(category);

        categoryDto.Id = category.Id;
        
        return categoryDto;
    }
    
    public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

        if (category is null)
        {
            throw new ArgumentException($"Category with id: {categoryId} not found");
        }
    
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> UpdateCategoryAsync(CategoryDto categoryDto)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(categoryDto.Id);

        if (category is null)
        {
            throw new ArgumentException($"Category with id: {categoryDto.Id} not found");          
        }
        
        category.CategoryName = categoryDto.CategoryName;
        
        await _categoryRepository.SaveAsync();
        
        return _mapper.Map<CategoryDto>(category);
        
    }

    public async Task DeleteCategoryAsync(int categoryId)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

        if (category is null)
        {
            throw new ArgumentException($"Category with id: {categoryId} not found");
        }

        await _categoryRepository.DeleteCategoryAsync(category);
    }
}