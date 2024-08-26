using Microsoft.AspNetCore.Mvc;
using RCountNewsFeedAPI.Models.DTOs;
using RCountNewsFeedAPI.Repositories.Interfaces;

namespace RCountNewsFeedAPI.Controllers;

[Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CategoryDto categoryDto)
    {
        try
        {
            return Ok(await _categoryRepository.CreateCategoryAsync(categoryDto));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _categoryRepository.GetCategoriesAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        try
        {
            var result = await _categoryRepository.GetCategoryByIdAsync(id);

            if (result is null)
                return NotFound("Category with specified id is not found!");
            
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody]CategoryDto categoryDto)
    {
        try
        {
            var result = await _categoryRepository.UpdateCategory(categoryDto);

            if (result is null)
                return NotFound("Category with specified id is not found!");
            
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _categoryRepository.DeleteCategory(id);

            if (!result)
                return NotFound("Category with specified id is not found!");
            
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}