using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyZero.Blog.IApplication.Configs.Dto
{
    public class BasicsSettingDto
    {
        /// <summary>
        /// 网站图标
        /// </summary>
        public string BlogIcon { get; set; }
        /// <summary>
        /// 网站标题
        /// </summary>
        public string BlogName { get; set; }
        /// <summary>
        /// 网站标题
        /// </summary>
        public string BlogInfo { get; set; }
        /// <summary>
        /// 网站标题
        /// </summary>
        public string BlogUrl { get; set; }
        /// <summary>
        /// 每页文章的数量
        /// </summary>
        public int IndexLogNum { get; set; }
        /// <summary>
        /// 版权说明 站点页底
        /// </summary>
        public string FooterInfo { get; set; }
        /// <summary>
        /// 上传文件类型
        /// </summary>
        public string AttType { get; set; }
        /// <summary>
        /// 上传文件大小
        /// </summary>
        public int AttMaxSize { get; set; }
        /// <summary>
        /// 是否关闭网站
        /// </summary>
        public bool IsClose { get; set; }
    }
}
