using AutoMapper;
using RCountNewsFeed.Models;
using RCountNewsFeed.Models.DTOs.Category;
using RCountNewsFeed.Models.DTOs.News;

namespace RCountNewsFeed.Core;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CategoryDto, Category>().ReverseMap();
        CreateMap<CreateNewsRequestDto, NewsDto>()
            .ForMember(dest => dest.Header, opt => opt.MapFrom(src => src.Header))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.CreatedByUserId, opt => opt.MapFrom(src => src.CreatedByUserId))
            .ForMember(dest => dest.UpdatedByUserId, opt => opt.MapFrom(src => src.UpdatedByUserId));
        CreateMap<NewsDto, News>().ReverseMap();
    }
}