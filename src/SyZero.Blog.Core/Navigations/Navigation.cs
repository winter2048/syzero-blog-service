using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Domain.Entities;

namespace SyZero.Blog.Core.Navigations
{
    public class Navigation : Entity
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
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 上级Id
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 是否在新窗口打开
        /// </summary>
        public bool IsNewTab { get; set; } = false;

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
