using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZero.Blog.Core.Links;
using SyZero.Blog.IApplication.Links.Dto;
using SyZero.Blog.IApplication.Links;
using SyZero.Domain.Repository;

namespace SyZero.Blog.Application.Links
{
    public class LinkAppService : AsyncCrudAppService<Link, LinkDto>, ILinkAppService
    {
        private readonly IRepository<Link> _linkRepository;

        public LinkAppService(IRepository<Link> linkRepository) : base(linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public async Task<List<LinkDto>> GetAll()
        {
            var pp = await _linkRepository.GetListAsync(p => p.IsHide == false);
            pp = pp.OrderBy(p => p.Order);

            return ObjectMapper.Map<List<LinkDto>>(pp.ToList());
        }
    }
}
