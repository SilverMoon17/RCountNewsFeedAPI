using AutoMapper;
using RCountNewsFeed.API.Repositories.Interfaces;
using RCountNewsFeed.Core.Services.Interfaces;
using RCountNewsFeed.Models;
using RCountNewsFeed.Models.DTOs.News;

namespace RCountNewsFeed.Core.Services;

public class NewsService : INewsService
{
    private readonly INewsRepository _newsRepository;
    private readonly ICategoryRepository _categoryRepository;
    
    private readonly IMapper _mapper;

    public NewsService(INewsRepository newsRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _newsRepository = newsRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<NewsDto> CreateNewsAsync(CreateNewsRequestDto createNewsRequestDto)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(createNewsRequestDto.CategoryId);
    
        if (category is null)
            throw new ArgumentException($"Category with Id {createNewsRequestDto.CategoryId} does not exist.", nameof(createNewsRequestDto.CategoryId));
    
        var newsModel = new News
        {
            Header = createNewsRequestDto.Header,
            Text = createNewsRequestDto.Text,
            ImageUrl = createNewsRequestDto.ImageUrl,
            Category = category,
            CreatedByUserId = createNewsRequestDto.CreatedByUserId,
            UpdatedByUserId = createNewsRequestDto.UpdatedByUserId
        };
        
        await _newsRepository.AddAsync(newsModel);
        
        return _mapper.Map<NewsDto>(newsModel);
    }

    public async Task<IEnumerable<NewsDto>> GetAllNewsAsync()
    {
        var news = await _newsRepository.GetAllNewsAsync();
        
        return _mapper.Map<IEnumerable<NewsDto>>(news);
    }

    public async Task<NewsDto> GetNewsByIdAsync(int id)
    {
        var news = await _newsRepository.GetNewsByIdAsync(id);

        if (news is null)
        {
            throw new ArgumentException($"News with Id {id} does not exist.", nameof(id));
        }
        
        return _mapper.Map<NewsDto>(news);
    }

    public async Task<IEnumerable<NewsDto>> GetLatestNewsAsync(int count)
    {
        if (count < 1)
            throw new ArgumentException("Count can't be lower than 1");
        
        var newsList = await _newsRepository.GetLatestNewsAsync(count);
    
        return _mapper.Map<IEnumerable<NewsDto>>(newsList);
    }
    
    public async Task<NewsDto> UpdateNewsAsync(UpdateNewsRequestDto updateNewsRequestDto)
    {
        var news = await _newsRepository.GetNewsByIdAsync(updateNewsRequestDto.Id);
    
        if (news is null)
            throw new ArgumentException($"News with Id {updateNewsRequestDto.Id} does not exist.", nameof(updateNewsRequestDto.Id));
        
        var category = await _categoryRepository.GetCategoryByIdAsync(updateNewsRequestDto.CategoryId);
        
        if (category is null)
            throw new ArgumentException($"Category with Id {updateNewsRequestDto.CategoryId} does not exist.", nameof(updateNewsRequestDto.CategoryId));
    
        news.Category = category;
        news.Updated = DateTime.UtcNow;
        news.Header = updateNewsRequestDto.Header;
        news.Text = updateNewsRequestDto.Text;
        news.ImageUrl = updateNewsRequestDto.ImageUrl;
        news.UpdatedByUserId = updateNewsRequestDto.UpdatedByUserId;
    
        await _newsRepository.SaveAsync();
    
        return _mapper.Map<NewsDto>(news);
    }

    public async Task DeleteNewsAsync(int id)
    {
        var news = await _newsRepository.GetNewsByIdAsync(id);

        if (news is null)
        {
            throw new ArgumentException($"News with Id {id} does not exist.", nameof(id));
        }
        
        await _newsRepository.DeleteNewsAsync(news);
    }
}