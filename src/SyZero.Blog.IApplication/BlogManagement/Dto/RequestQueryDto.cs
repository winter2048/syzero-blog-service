using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyZero.Blog.IApplication.BlogManagement.Dto
{
    public class RequestQueryDto : PageAndSortFilterQueryDto
    {


        /// <summary>
        /// 分类
        /// </summary>
        public string Class { get; set; }
    }
}
