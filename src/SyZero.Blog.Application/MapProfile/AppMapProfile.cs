using AutoMapper;
using System.Collections.Generic;
using SyZero.Authorization.IApplication.Users.Dto;
using SyZero.Blog.Core.BlogManagement;
using SyZero.Blog.Core.Links;
using SyZero.Blog.Core.Navigations;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Blog.IApplication.Links.Dto;
using SyZero.Blog.IApplication.Navigations.Dto;
using SyZero.Blog.IApplication.Pages.Dto;

namespace SyZero.Blog.Application.MapProfile
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            CreateMap<ArticleDto, Article>();
            CreateMap<Article, ArticleDto>().ForMember(des => des.CreateTime, opt => opt.MapFrom(p => p.CreateTime.ToDateTimeFormat("yyyy-MM-dd HH:mm:ss")));
            CreateMap<CreateArticleDto, Article>();

            CreateMap<CreateArticleCategoryDto, ArticleCategory>();
            CreateMap<ArticleCategory, CreateArticleCategoryDto>();

            CreateMap<ArticleCategoryDto, ArticleCategory>();
            CreateMap<ArticleCategory, ArticleCategoryDto>();

            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();

            CreateMap<Comment, CreateCommentDto>();
            CreateMap<CreateCommentDto, Comment>();

            CreateMap<TagDto, Tag>();
            CreateMap<Tag, TagDto>();

            CreateMap<LinkDto, Link>();
            CreateMap<Link, LinkDto>();

            CreateMap<NavigationDto, Navigation>();
            CreateMap<Navigation, NavigationDto>();

            CreateMap<CreateNavigationDto, Navigation>();
            CreateMap<Navigation, CreateNavigationDto>();

            CreateMap<PageDto, Article>();
            CreateMap<Article, PageDto>().ForMember(des => des.CreateTime, opt => opt.MapFrom(p => p.CreateTime.ToDateTimeFormat("yyyy-MM-dd HH:mm:ss")));
            CreateMap<CreatePageDto, Article>();
            CreateMap<Article, CreatePageDto>();
        }
    }
}