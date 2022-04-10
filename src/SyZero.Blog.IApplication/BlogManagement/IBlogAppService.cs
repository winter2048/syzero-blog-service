using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using SyZero.Application.Attributes;
using SyZero.Application.Routing;
using SyZero.Web.Common;

namespace SyZero.Blog.IApplication.Users
{
    public interface IBlogAppService : IApplicationServiceBase
    {
        /// <summary>
        /// 获取登录人信息
        /// </summary>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET)]
        Task<object> GetInfo();
    }
}



