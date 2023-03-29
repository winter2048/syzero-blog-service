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
    public class ArticleAppServiceFallback : IArticleAppService, IFallback
    {
        private readonly ILogger _logger;

        public ArticleAppServiceFallback(ILogger logger)
        {
            _logger = logger;
        }

    


    }
}
