using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using SyZero.Application.Attributes;
using SyZero.Application.Routing;
using SyZero.Application.Service.Dto;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Web.Common;

namespace SyZero.Blog.IApplication.Users
{
    public interface IArticleAppService : IApplicationServiceBase
    {
        /// <summary>
        /// 分页获取博客文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET, "ShowAll")]
        Task<PageResultDto<ArticleDto>> GetShowAll(RequestQueryDto input);

        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET, "ShowInfo/{id}")]
        Task<ArticleDto> GetShowInfo(long id);

        /// <summary>
        /// 获取所有收藏/喜欢文章
        /// </summary>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET, "ShowCollectionAll")]
        Task<PageResultDto<ArticleDto>> GetShowCollectionAll(CollectionQueryDto input);

        /// <summary>
        /// 添加/取消收藏博客
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ApiMethod(HttpMethod.POST, "{Id}/CollectionBlog/{Type}/{IsAdd}")]
        Task<bool> CollectionBlog(long Id, int Type, bool IsAdd);
        /// <summary>
        /// 是否收藏/喜欢博客
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET, "{Id}/IsCollectionBlog/{Type}")]
        Task<bool> IsCollectionBlog(long Id, int Type);
        /// <summary>
        /// 获取所以博客文章（SEO）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET, "GetAllBlog")]
        Task<ListResultDto<SimpBlogDto>> GetAllBlog();

    }
}



