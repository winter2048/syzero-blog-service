using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Domain.Entities;

namespace SyZero.Blog.Core.BlogManagement
{
    /// <summary>
    /// 博文
    /// </summary>
    public class Article : Entity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        public string CategoryIds { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string TagIds { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; } = 0;
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 模板
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// 是否顶置
        /// </summary>
        public bool IsTop { get; set; } = false;
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; } = 0;
        /// <summary>
        /// 点赞次数
        /// </summary>
        public int LikeNums { get; set; } = 0;
        /// <summary>
        /// 查看次数
        /// </summary>
        public int ViewNums { get; set; } = 0;
        /// <summary>
        /// 创建人
        /// </summary>
        public long CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
