using AutoMapper;
using System.Collections.Generic;
using SyZero.Authorization.IApplication.Users.Dto;
using SyZero.Blog.Core.BlogManagement;
using SyZero.Blog.IApplication.BlogManagement.Dto;

namespace SyZero.Blog.Application.MapProfile
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<ArticleDto, Article>();
            CreateMap<Article, ArticleDto>();
            CreateMap<CreateArticleDto, Article>();
        }
    }
}