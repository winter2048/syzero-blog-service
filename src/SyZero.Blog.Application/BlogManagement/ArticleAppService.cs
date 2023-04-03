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
using System.Linq;

namespace SyZero.Blog.Application.BlogManagement
{
    public class ArticleAppService : AsyncCrudAppService<Article, ArticleDto, PageAndSortFilterQueryDto, CreateArticleDto>, IArticleAppService
    {
        private readonly IRepository<ArticleTag> _articleTagRepository;
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<Tag> _tagRepository;
        private readonly IAuthAppService _authAppService;

        public ArticleAppService(IRepository<ArticleTag> articleTagRepository,
            IRepository<Article> articleRepository,
            IRepository<Tag> tagRepository,
            IAuthAppService authAppService) : base(articleRepository)
        {
            _articleTagRepository = articleTagRepository;
            _articleRepository = articleRepository;
            _tagRepository = tagRepository;
            _authAppService = authAppService;
        }

        public async override Task<ArticleDto> Get(long id)
        {
            CheckUpdatePermission();
            var entity = await _articleRepository.GetModelAsync(id);
            var tagIds1 = (await _articleTagRepository.GetListAsync(p => p.ArticleId == id));
            var tagIds = (await _articleTagRepository.GetListAsync(p => p.ArticleId == id)).Select(p => p.TagId).ToList();
            var tags = await _tagRepository.GetListAsync(p => tagIds.Contains(p.Id));
            var dto = MapToEntityDto(entity);
            dto.Tags = tags.ToList().Select(p => ObjectMapper.Map<TagDto>(p)).ToList();
            return dto;
        }

        public async override Task<ArticleDto> Update(long id, CreateArticleDto input)
        {
            CheckUpdatePermission();
            var entity = await GetEntityByIdAsync(id);
            MapToEntity(input, entity);
            await _articleTagRepository.DeleteAsync(p => p.ArticleId == id);
            await _articleTagRepository.AddListAsync(input.Tags.Select(p => new ArticleTag { ArticleId = id, TagId = p.ToLong() }).AsQueryable());
            await Repository.UpdateAsync(entity);

            var dto = MapToEntityDto(entity);
            var tagIds = (await _articleTagRepository.GetListAsync(p => p.ArticleId == id)).Select(p => p.TagId).ToList();
            var tags = await _tagRepository.GetListAsync(p => tagIds.Contains(p.Id));
            dto.Tags = tags.ToList().Select(p => ObjectMapper.Map<TagDto>(p)).ToList();

            return MapToEntityDto(entity);
        }
    }
}



