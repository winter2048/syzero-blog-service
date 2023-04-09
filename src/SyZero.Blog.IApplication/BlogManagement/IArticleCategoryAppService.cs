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
    public interface  IArticleCategoryAppService : IApplicationServiceBase
    {
        /// <summary>
        /// 获取所有文章分类
        /// </summary>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET, "ShowAll")]
        Task<ListResultDto<ArticleCategoryDto>> GetShowAll();
    }
}
