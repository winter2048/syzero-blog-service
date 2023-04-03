using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service.Dto;
using SyZero.Application.Service;
using SyZero.Blog.IApplication.Pages.Dto;
using SyZero.Blog.IApplication.Pages;
using SyZero.Domain.Repository;
using SyZero.Blog.Core.BlogManagement;
using SyZero.Blog.IApplication.BlogManagement.Dto;

namespace SyZero.Blog.Application.Pages
{
    public class PageAppService : AsyncCrudAppService<Article, PageDto, PageAndSortQueryDto, CreateArticleDto>, IPageAppService
    {
        private readonly IRepository<Article> _blogRepository;
        public PageAppService(IRepository<Article> blogRepository) : base(blogRepository)
        {
            _blogRepository = blogRepository;
        }
    }
}
