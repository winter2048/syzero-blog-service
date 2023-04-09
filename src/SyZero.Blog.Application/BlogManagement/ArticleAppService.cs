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
using System.Threading;
using Castle.DynamicProxy.Contributors;
using SqlSugar;

namespace SyZero.Blog.Application.BlogManagement
{
    public class ArticleAppService : AsyncCrudAppService<Article, ArticleDto, PageAndSortFilterQueryDto, CreateArticleDto>, IArticleAppService
    {
        private readonly IRepository<ArticleTag> _articleTagRepository;
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<ArticleCategory> _articleCategoryRepository;
        private readonly IRepository<Tag> _tagRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<LikeArticle> _likeArticleRepository;
        private readonly IAuthAppService _authAppService;
        private readonly IUserAppService _userAppService;

        public ArticleAppService(IRepository<ArticleTag> articleTagRepository,
            IRepository<Article> articleRepository,
            IRepository<ArticleCategory> articleCategoryRepository,
            IRepository<Tag> tagRepository,
            IAuthAppService authAppService,
            IUserAppService userAppService,
            IRepository<Comment> commentRepository,
            IRepository<LikeArticle> likeArticleRepository) : base(articleRepository)
        {
            _articleTagRepository = articleTagRepository;
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
            _tagRepository = tagRepository;
            _authAppService = authAppService;
            _userAppService = userAppService;
            _commentRepository = commentRepository;
            _likeArticleRepository = likeArticleRepository;
        }
     
        protected override async Task<IQueryable<Article>> CreateFilteredQueryAsync(PageAndSortFilterQueryDto input)
        {
            var q = await base.CreateFilteredQueryAsync(input);
            return q.Where(p => p.Type == "1");
        }

        protected override Article MapToEntity(CreateArticleDto createInput)
        {
            var entity = base.MapToEntity(createInput);
            entity.Type = "1";
            return entity;
        }

        public async override Task<PageResultDto<ArticleDto>> List(PageAndSortFilterQueryDto input)
        {
            var list = await base.List(input);
            var articleCategoryList = (await _articleCategoryRepository.GetListAsync()).ToList();
            foreach (var item in list.list)
            {
                item.CategoryName = articleCategoryList.FirstOrDefault(p => p.Id == item.CategoryId)?.Name;
                item.CreateUserName = item.CreateUserId.HasValue ? (await _userAppService.GetUser(item.CreateUserId.Value))?.Name : "";
            }
            return list;
        }

        public async override Task<ArticleDto> Get(long id)
        {
            CheckGetPermission();
            var entity = await _articleRepository.GetModelAsync(id);
            var tagIds1 = (await _articleTagRepository.GetListAsync(p => p.ArticleId == id));
            var tagIds = (await _articleTagRepository.GetListAsync(p => p.ArticleId == id)).Select(p => p.TagId).ToList();
            var tags = await _tagRepository.GetListAsync(p => tagIds.Contains(p.Id));
            var dto = MapToEntityDto(entity);
            dto.Tags = tags.ToList().Select(p => ObjectMapper.Map<TagDto>(p)).ToList();
            return dto;
        }

        public async override Task<ArticleDto> Create(CreateArticleDto input)
        {
            CheckUpdatePermission();
            var entity = MapToEntity(input);
            entity.CreateUserId = SySession.UserId;
            await _articleTagRepository.AddListAsync(input.Tags.Select(p => new ArticleTag { ArticleId = entity.Id, TagId = p.ToLong() }).AsQueryable());
            await Repository.AddAsync(entity);

            var dto = MapToEntityDto(entity);
            var tagIds = (await _articleTagRepository.GetListAsync(p => p.ArticleId == entity.Id)).Select(p => p.TagId).ToList();
            var tags = await _tagRepository.GetListAsync(p => tagIds.Contains(p.Id));
            dto.Tags = tags.ToList().Select(p => ObjectMapper.Map<TagDto>(p)).ToList();

            return MapToEntityDto(entity);
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

        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        public async Task<PageResultDto<ArticleDto>> GetShowAll(RequestQueryDto input)
        {
            var query = await _articleRepository.GetListAsync(p => p.Status == 1);
            //if (!String.IsNullOrEmpty(input.Class))
            //{
            //    query = query.Where(p => p.Category.Id == input.Class.ToLong() || p.Category.Alias == input.Class || p.Category.Parent.Id == input.Class.ToLong() || p.Category.Parent.Alias == input.Class);
            //}
            //if (!String.IsNullOrEmpty(input.Key))
            //{
            //    query = query.Where(p => p.Title.Contains(input.Key));
            //}
            query = query.Where(p => p.Type == "1");
            var totalCount = query.Count();

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = query.ToList();

            return new PageResultDto<ArticleDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }

        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ArticleDto> GetShowInfo(long id)
        {
            var entity = await _articleRepository.GetModelAsync(id);
            entity.ViewNums++;
            await _articleRepository.UpdateAsync(entity);
            return MapToEntityDto(entity);
        }

        public async Task<PageResultDto<ArticleDto>> GetShowCollectionAll(CollectionQueryDto input)
        {
            CheckPermission("");
            var user = await _userAppService.GetUser(SySession.UserId.Value);


            var likeArticles = await _likeArticleRepository.GetListAsync(p => p.Type == input.Type);

            var likeIds = likeArticles.Select(p => p.ArticleId).ToList();

            var query = await _articleRepository.GetListAsync(p => likeIds.Contains(p.Id));

            query = query.Where(p => p.Type == "1");
            if (!String.IsNullOrEmpty(input.Class))
            {
                query = query.Where(p => p.CategoryId == input.Class.ToLong());
            }

            if (!String.IsNullOrEmpty(input.Key))
            {
                query = query.Where(p => p.Title.Contains(input.Key));
            }

            var totalCount = query.Count();

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = query.ToList();

            return new PageResultDto<ArticleDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }

        public async Task<bool> CollectionBlog(long Id, int Type, bool IsAdd)
        {
            CheckPermission("");

            var likeArticles = await _likeArticleRepository.GetListAsync(p => p.UserId == SySession.UserId.Value);

            if (likeArticles.Count(p => p.ArticleId == Id && p.Type == Type) <= 0 && IsAdd)
            {
                await _likeArticleRepository.AddAsync(new LikeArticle()
                {
                    ArticleId = Id,
                    UserId = SySession.UserId.Value,
                    Type = Type
                });
            }
            else if (likeArticles.Count(p => p.ArticleId == Id && p.Type == Type) > 0 && !IsAdd)
            {
                await _likeArticleRepository.DeleteAsync(p => p.ArticleId == Id && p.Type == Type);
            }

            return true;
        }

        public async Task<bool> IsCollectionBlog(long Id, int Type)
        {
            CheckPermission("");
            return (await _likeArticleRepository.CountAsync(p => p.ArticleId == Id && p.Type == Type)) > 0;
        }

        public async Task<ListResultDto<SimpBlogDto>> GetAllBlog()
        {
            var query = await _articleRepository.GetListAsync(p => p.Status == 1 && p.Type == "1");

            var entities = query.ToList();

            return new ListResultDto<SimpBlogDto>(entities.Select(p => ObjectMapper.Map<SimpBlogDto>(p)).ToList());
        }
    }
}



