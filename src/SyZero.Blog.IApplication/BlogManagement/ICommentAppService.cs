using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Routing;
using SyZero.Application.Service.Dto;
using SyZero.Blog.IApplication.BlogManagement.Dto;

namespace SyZero.Blog.IApplication.BlogManagement
{
    public interface ICommentAppService : IApplicationServiceBase
    {

        /// <summary>
        /// 获取文章评论
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET, "Blog/{BlogId}")]
        Task<PageResultDto<CommentDto>> GetBlogComment(long BlogId, PageAndSortQueryDto input);

        /// <summary>
        /// 发送文章评论
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [ApiMethod(HttpMethod.POST, "Blog/{BlogId}")]
        Task<bool> SendComment(long BlogId, CreateCommentDto dto);
    }
}
