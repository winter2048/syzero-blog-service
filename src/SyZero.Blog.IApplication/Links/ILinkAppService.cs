using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Routing;
using SyZero.Application.Service;
using SyZero.Blog.IApplication.Links.Dto;

namespace SyZero.Blog.IApplication.Links
{
    public interface ILinkAppService : IAsyncCrudAppService<LinkDto>, IApplicationServiceBase
    { 
        /// <summary>
       /// 获取友情链接
       /// </summary>
       /// <returns></returns>
        [Get("All")]
        Task<List<LinkDto>> GetAll();
    }
}
