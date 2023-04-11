using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZero.Blog.Core.BlogManagement;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Blog.IApplication.BlogManagement;
using SyZero.Domain.Repository;

namespace SyZero.Blog.Application.BlogManagement
{
    public class TagAppService : AsyncCrudAppService<Tag, TagDto>, ITagAppService
    {
        private readonly IRepository<Tag> _tagRepository;
        public TagAppService(IRepository<Tag> tagRepository) : base(tagRepository)
        {
            _tagRepository = tagRepository;
        }

    }
}
