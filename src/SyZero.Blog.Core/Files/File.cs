using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Domain.Entities;

namespace SyZero.Blog.Core.Files
{
    /// <summary>
    /// 文件
    /// </summary>
    public class File : Entity
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 原文件名
        /// </summary>
        public string SourceName { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public int Size { get; set; } = 0;
        /// <summary>
        /// 来源
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public long CreateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
