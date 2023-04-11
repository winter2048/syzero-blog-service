using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Blog.IApplication.BlogManagement.Dto;

namespace SyZero.Blog.IApplication.BlogManagement
{
    public class ArticleCategoryAppServiceFallback : IArticleCategoryAppService
    {
        public Task<Application.Service.Dto.ListResultDto<ArticleCategoryDto>> GetShowAll()
        {
            throw new NotImplementedException();
        }
    }
}
