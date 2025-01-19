using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service.Dto;
using SyZero.Blog.IApplication.BlogManagement.Dto;

namespace SyZero.Blog.IApplication.BlogManagement
{
    public class ArticleCategoryAppServiceFallback : IArticleCategoryAppService
    {
        public Task<ArticleCategoryDto> Create(CreateArticleCategoryDto input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleCategoryDto> Get(long input)
        {
            throw new NotImplementedException();
        }

        public Task<Application.Service.Dto.ListResultDto<ArticleCategoryDto>> GetShowAll()
        {
            throw new NotImplementedException();
        }

        public Task<PageResultDto<ArticleCategoryDto>> List(PageAndSortQueryDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleCategoryDto> Update(long id, ArticleCategoryDto input)
        {
            throw new NotImplementedException();
        }
    }
}
