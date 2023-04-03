using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service.Dto;
using SyZero.Application.Service;
using SyZero.Blog.Core.BlogManagement;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Blog.IApplication.BlogManagement;
using SyZero.Domain.Repository;

namespace SyZero.Blog.Application.BlogManagement
{
    public class ArticleCategoryAppService : AsyncCrudAppService<ArticleCategory, ArticleCategoryDto, PageAndSortQueryDto, CreateArticleCategoryDto>, IArticleCategoryAppService
    {
        private readonly IRepository<ArticleCategory> _articleCateRepository;

        public ArticleCategoryAppService(IRepository<ArticleCategory> articleCateRepository) : base(articleCateRepository)
        {
            _articleCateRepository= articleCateRepository;
        }
    }
}
