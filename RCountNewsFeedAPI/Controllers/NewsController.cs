using Microsoft.AspNetCore.Mvc;
using RCountNewsFeedAPI.Models.DTOs;
using RCountNewsFeedAPI.Repositories.Interfaces;

namespace RCountNewsFeedAPI.Controllers;

[Route("api/news")]
public class NewsController : ControllerBase
{
    private readonly INewsRepository _newsRepository;

    public NewsController(INewsRepository newsRepository)
    {
        _newsRepository = newsRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNewsRequestDto newsDto)
    {
        try
        {
            return Ok(await _newsRepository.CreateNewsAsync(newsDto));
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
            return Ok(await _newsRepository.GetAllNewsAsync());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAll(int id)
    {
        try
        {
            return Ok(await _newsRepository.GetNewsByIdAsync(id));
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
            return Ok(await _newsRepository.GetLatestNewsAsync(count));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateNewsRequestDto updateNewsRequestDto)
    {
        try
        {
            return Ok(await _newsRepository.UpdateNews(updateNewsRequestDto));
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
            return Ok(await _newsRepository.DeleteNews(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}