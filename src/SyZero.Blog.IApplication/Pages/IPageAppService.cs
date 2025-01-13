using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service.Dto;
using SyZero.Application.Service;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Blog.IApplication.Pages.Dto;

namespace SyZero.Blog.IApplication.Pages
{
    public interface IPageAppService : IAsyncCrudAppService<PageDto, PageAndSortQueryDto, CreateArticleDto>, IApplicationServiceBase
    {
    }
}
