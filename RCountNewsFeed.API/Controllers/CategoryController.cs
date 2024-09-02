using Microsoft.AspNetCore.Mvc;
using RCountNewsFeed.Core.Services.Interfaces;
using RCountNewsFeed.Models.DTOs.Category;

namespace RCountNewsFeed.API.Controllers;

[Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CategoryDto categoryDto)
    {
        try
        {
            return Ok(await _categoryService.CreateCategoryAsync(categoryDto));
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
            var result = await _categoryService.GetCategoryByIdAsync(id);
            
            return Ok(result);
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
            return Ok(await _categoryService.GetAllCategories());
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
            var result = await _categoryService.UpdateCategoryAsync(categoryDto);
            
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
            await _categoryService.DeleteCategoryAsync(id);
    
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}