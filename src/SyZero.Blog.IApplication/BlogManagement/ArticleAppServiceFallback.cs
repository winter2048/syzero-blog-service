using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service.Dto;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Cache;
using SyZero.Client;
using SyZero.Logger;
using SyZero.Runtime.Security;
using SyZero.Serialization;
using SyZero.Web.Common;

namespace SyZero.Blog.IApplication.Users
{
    public class ArticleAppServiceFallback : IArticleAppService, IFallback
    {
        private readonly ILogger _logger;

        public ArticleAppServiceFallback(ILogger logger)
        {
            _logger = logger;
        }

        public Task<bool> CollectionBlog(long Id, int Type, bool IsAdd)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDto> Create(CreateArticleDto input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDto> Get(long input)
        {
            throw new NotImplementedException();
        }

        public Task<ListResultDto<SimpBlogDto>> GetAllBlog()
        {
            throw new NotImplementedException();
        }

        public Task<PageResultDto<ArticleDto>> GetShowAll(RequestQueryDto input)
        {
            throw new NotImplementedException();
        }

        public Task<PageResultDto<ArticleDto>> GetShowCollectionAll(CollectionQueryDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDto> GetShowInfo(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsCollectionBlog(long Id, int Type)
        {
            throw new NotImplementedException();
        }

        public Task<PageResultDto<ArticleDto>> List(PageAndSortFilterQueryDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDto> Update(long id, ArticleDto input)
        {
            throw new NotImplementedException();
        }
    }
}
