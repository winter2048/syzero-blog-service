using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Routing;
using SyZero.Application.Service.Dto;
using SyZero.Application.Service;
using SyZero.Blog.IApplication.Navigations.Dto;

namespace SyZero.Blog.IApplication.Navigations
{
    public interface INavigationAppService : IAsyncCrudAppService<NavigationDto, PageAndSortQueryDto, CreateNavigationDto>, IApplicationServiceBase
    {
        [Get("All")]
        Task<List<NavigationDto>> GetAll();
    }
}
