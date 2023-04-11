using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Routing;
using SyZero.Blog.IApplication.Links.Dto;

namespace SyZero.Blog.IApplication.Links
{
    public interface ILinkAppService : IApplicationServiceBase
    { 
        /// <summary>
       /// 获取友情链接
       /// </summary>
       /// <returns></returns>
        [ApiMethod(HttpMethod.GET, "All")]
        Task<List<LinkDto>> GetAll();
    }
}
