using Microsoft.AspNetCore.Mvc;
using RCountNewsFeed.API.Models.DTOs;
using RCountNewsFeed.Core.Services.Interfaces;
using RCountNewsFeed.Models;

namespace RCountNewsFeed.API.Controllers;

[ApiController]
[Route("api/project")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject(ProjectDto project)
    {
        try
        {
            return Ok(await _projectService.CreateProjectAsync(project));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        try
        {
            var result = await _projectService.GetProjectByIdAsync(id);
            
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
            return Ok(await _projectService.GetAllProjectsAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody]ProjectDto projectDto)
    {
        try
        {
            var result = await _projectService.UpdateProjectAsync(projectDto);
            
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
            await _projectService.DeleteProjectAsync(id);
    
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}