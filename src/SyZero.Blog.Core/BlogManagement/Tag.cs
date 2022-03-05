using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Domain.Entities;

namespace SyZero.Blog.Core.BlogManagement
{ 
    public class Tag : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
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
    }
}
