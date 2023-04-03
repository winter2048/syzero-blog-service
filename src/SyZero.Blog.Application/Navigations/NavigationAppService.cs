using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service.Dto;
using SyZero.Application.Service;
using SyZero.Blog.Core.Navigations;
using SyZero.Blog.IApplication.Navigations.Dto;
using SyZero.Domain.Repository;
using SyZero.Blog.IApplication.Navigations;

namespace SyZero.Blog.Application.Navigations
{
    public class NavigationAppService : AsyncCrudAppService<Navigation, NavigationDto, PageAndSortQueryDto, CreateNavigationDto>, INavigationAppService
    {
        private readonly IRepository<Navigation> _navigationRepository;

        public NavigationAppService(IRepository<Navigation> navigationRepository) : base(navigationRepository)
        {
            _navigationRepository = navigationRepository;
        }
    }
}
