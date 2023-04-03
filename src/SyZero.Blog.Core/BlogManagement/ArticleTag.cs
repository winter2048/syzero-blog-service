using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Domain.Entities;

namespace SyZero.Blog.Core.BlogManagement
{
    public class ArticleTag : Entity
    {
        public long ArticleId { get; set; }

        public long TagId { get; set; }
    }
}
