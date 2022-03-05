using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Domain.Entities;

namespace SyZero.Blog.Core.Links
{
    public class Link : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool IsHide { get; set; } = false;

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; } = 0;

    }
}
