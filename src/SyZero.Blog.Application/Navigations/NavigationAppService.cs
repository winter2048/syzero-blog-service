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

        /// <summary>
        /// 获取导航栏
        /// </summary>
        /// <returns></returns>
        public async Task<List<NavigationDto>> GetAll()
        {
            var pp = await _navigationRepository.GetListAsync(p => p.IsHide == false);
            var allList = pp.OrderBy(p => p.Order);
            var fList = allList.Where(p => p.ParentId == null);

            var dtoList = ObjectMapper.Map<List<NavigationDto>>(fList.ToList());
            foreach (var p in dtoList)
            {
                p.Childs = ObjectMapper.Map<List<NavigationDto>>(allList.Where(x => x.ParentId == p.Id).ToList());
            }

            return dtoList;
        }

    }
}
