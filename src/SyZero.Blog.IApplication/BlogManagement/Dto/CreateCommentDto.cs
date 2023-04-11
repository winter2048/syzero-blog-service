using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyZero.Blog.IApplication.BlogManagement.Dto
{
    public class CreateCommentDto
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }


        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 上级Id
        /// </summary>
        public long? ParentId { get; set; }
    }
}
