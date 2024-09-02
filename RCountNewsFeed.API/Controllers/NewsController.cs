using Microsoft.AspNetCore.Mvc;
using RCountNewsFeed.API.Models.DTOs;
using RCountNewsFeed.API.Repositories.Interfaces;
using RCountNewsFeed.Core.Services.Interfaces;
using RCountNewsFeed.Models.DTOs.News;

namespace RCountNewsFeed.API.Controllers;

[Route("api/news")]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNewsRequestDto newsDto)
    {
        try
        {
            return Ok(await _newsService.CreateNewsAsync(newsDto));
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
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
            return Ok(await _newsService.GetAllNewsAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _newsService.GetNewsByIdAsync(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("latest_news")]
    public async Task<IActionResult> GetLatestNews([FromQuery]int count)
    {
        try
        {
            return Ok(await _newsService.GetLatestNewsAsync(count));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody]UpdateNewsRequestDto updateNewsRequestDto)
    {
        try
        {
            return Ok(await _newsService.UpdateNewsAsync(updateNewsRequestDto));
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
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
            await _newsService.DeleteNewsAsync(id);
            
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}