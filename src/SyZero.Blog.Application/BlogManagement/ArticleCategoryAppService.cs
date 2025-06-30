using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZero.Application.Service.Dto;
using SyZero.Blog.Core.BlogManagement;
using SyZero.Blog.IApplication.BlogManagement;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Domain.Repository;
using SyZero.Util;
using SyZero.Web.Common;

namespace SyZero.Blog.Application.BlogManagement
{
    public class ArticleCategoryAppService : AsyncCrudAppService<ArticleCategory, ArticleCategoryDto, PageAndSortQueryDto, CreateArticleCategoryDto>, IArticleCategoryAppService
    {
        private readonly IRepository<ArticleCategory> _articleCateRepository;

        public ArticleCategoryAppService(IRepository<ArticleCategory> articleCateRepository) : base(articleCateRepository)
        {
            _articleCateRepository= articleCateRepository;
        }

        public async Task<ListResultDto<ArticleCategoryDto>> GetShowAll()
        {
            Logger.LogTrace("这是跟踪日志");
            Logger.LogDebug("这是调试日志");
            Logger.LogInformation("这是信息日志");
            Logger.LogWarning("这是警告日志");
            Logger.LogError("这是错误日志");
            Logger.LogCritical("这是严重错误");
            var pp = await _articleCateRepository.GetListAsync();
            var list = pp.ToList().Where(p => p.ParentId == null).Select(MapToEntityDto).ToList();
            return new ListResultDto<ArticleCategoryDto>(list);
        }
    }
}
