using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyZero.Blog.IApplication.Configs.Dto
{
    public class SeoSettingDto
    {
        /// <summary>
        /// SEO浏览器站点标题
        /// </summary>
        public string SeoTitle { get; set; }
        /// <summary>
        /// SEO浏览器站点关键字
        /// </summary>
        public string SeoKeywords { get; set; }
        /// <summary>
        /// SEO浏览器站点描述
        /// </summary>
        public string SeoDescription { get; set; }
        /// <summary>
        /// 文章标题方案
        /// </summary>
        public TitleStyle SeoTitleStyle { get; set; }
    }

    public enum TitleStyle
    {
        文章标题 = 0,
        文章标题_站点标题 = 1,
        文章标题_站点浏览器标题 = 2
    }
}
