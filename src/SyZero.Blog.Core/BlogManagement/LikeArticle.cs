using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Domain.Entities;

namespace SyZero.Blog.Core.BlogManagement
{
    public class LikeArticle : Entity
    {
        /// <summary>
        /// 博文Id
        /// </summary>
        public long ArticleId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; } = 0;
    }
}
