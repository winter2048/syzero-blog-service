using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Cache;
using SyZero.Client;
using SyZero.Logger;
using SyZero.Runtime.Security;
using SyZero.Serialization;
using SyZero.Web.Common;

namespace SyZero.Blog.IApplication.Users
{
    public class BlogAppServiceFallback : IBlogAppService, IFallback
    {
        private readonly ILogger _logger;

        public BlogAppServiceFallback(ILogger logger)
        {
            _logger = logger;
        }

        public Task<object> Login(Login2Dto input)
        {
            _logger.Error("Fallback => AuthAppService:Login");
            return null;
        }


    }
}
