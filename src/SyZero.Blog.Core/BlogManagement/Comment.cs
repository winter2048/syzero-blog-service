using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Domain.Entities;

namespace SyZero.Blog.Core.BlogManagement
{
    public class Comment : Entity
    {
        /// <summary>
        /// 博文Id
        /// </summary>
        public long BlogId { get; set; }

        /// <summary>
        /// 上级Id
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 发表人
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; } = 0;
        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人Id
        /// </summary>
        public long? CreateUserId { get; set; }
    }
}
