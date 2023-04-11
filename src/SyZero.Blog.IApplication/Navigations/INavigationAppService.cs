using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Routing;
using SyZero.Blog.IApplication.Navigations.Dto;

namespace SyZero.Blog.IApplication.Navigations
{
    public interface INavigationAppService : IApplicationServiceBase
    {
        [ApiMethod(HttpMethod.GET, "All")]
        Task<List<NavigationDto>> GetAll();
    }
}
