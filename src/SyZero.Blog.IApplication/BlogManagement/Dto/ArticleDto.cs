using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service.Dto;

namespace SyZero.Blog.IApplication.BlogManagement.Dto
{
    public class ArticleDto : EntityDto
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
        /// 作者
        /// </summary>
        public long? CreateUserId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; } = 0;
        /// <summary>
        /// 模板
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public long? CategoryId { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int CommentNums { get; set; }
        /// <summary>
        /// 查看次数
        /// </summary>
        public int ViewNums { get; set; }
        /// <summary>
        /// 是否顶置
        /// </summary>
        public bool IsTop { get; set; } = false;
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; } = 0;

        /// <summary>
        /// 标签
        /// </summary>
        public List<TagDto> Tags { get; set; }
    }
}
