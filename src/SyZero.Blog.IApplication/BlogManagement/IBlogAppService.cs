﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using SyZero.Application.Attributes;
using SyZero.Application.Routing;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Web.Common;

namespace SyZero.Blog.IApplication.Users
{
    public interface IBlogAppService : IApplicationServiceBase
    {
        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [ApiMethod(HttpMethod.POST)]
        Task<string> Login(Login2Dto input);

    }
}



