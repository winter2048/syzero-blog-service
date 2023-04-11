using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SyZero.Domain.Entities;

namespace SyZero.Blog.Core.BlogManagement
{
    /// <summary>
    /// 博文分类
    /// </summary>
    public class ArticleCategory : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; } = 0;


        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 上级Id
        /// </summary>
        public long? ParentId { get; set; }
    }
}
