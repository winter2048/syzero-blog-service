using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Attributes;
using SyZero.Application.Routing;
using SyZero.Application.Service;
using SyZero.Web.Common;

namespace SyZero.Blog.IApplication
{
    public interface IConfigAppService : IApplicationServiceBase
    {
        /// <summary>
        /// 测试水水水水水水水水水水水
        /// </summary>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET)]
        Task<string> ConfigInfo();

        /// <summary>
        /// 测试水水水水水水水水水水水
        /// </summary>
        /// <returns></returns>
        [ApiMethod(HttpMethod.POST)]
        Task<string> ConfigInfo(int pp);

        /// <summary>
        ///  xxxxxxxxxx GetConfigInfo(int num, bool isok)
        /// </summary>
        /// <param name="num">4444</param>
        /// <param name="isok">5555</param>
        /// <returns></returns>
        [NonDynamicMethod]
        [ApiMethod(HttpMethod.POST)]
        Task<string> PostConfigInfo(int num, bool isok);
    }
}



