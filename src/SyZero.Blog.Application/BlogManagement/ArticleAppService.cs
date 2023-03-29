using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZero.Application.Service.Dto;
using SyZero.Authorization.IApplication.Users;
using SyZero.Authorization.IApplication.Users.Dto;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Blog.IApplication.Users;
using SyZero.Blog.Repository;
using SyZero.Cache;
using SyZero.Logger;
using SyZero.Runtime.Security;
using SyZero.Runtime.Session;
using SyZero.Serialization;
using SyZero.Web.Common;
using SyZero.Blog.Core.BlogManagement;
using SyZero.Domain.Repository;

namespace SyZero.Blog.Application.BlogManagement
{
    public class ArticleAppService : AsyncCrudAppService<Article, ArticleDto, PageAndSortFilterQueryDto, CreateArticleDto>, IArticleAppService
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IAuthAppService _authAppService;

        public ArticleAppService(IRepository<Article> articleRepository, IAuthAppService authAppService) : base(articleRepository)
        {
            _articleRepository = articleRepository;
            _authAppService = authAppService;
        }

    }  
}



