using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyZero.Blog.IApplication.Configs.Dto
{
    public class SmsConfigDto
    {
        /// <summary>
        /// 密匙ID
        /// </summary>
        public string AccessKeyID { get; set; }
        /// <summary>
        /// 密匙
        /// </summary>
        public string AccessKeySecret { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string SignName { get; set; }
        /// <summary>
        /// 注册模板码
        /// </summary>
        public string RegisterCode { get; set; }
        /// <summary>
        /// 登录模板码
        /// </summary>
        public string SignInCode { get; set; }
        /// <summary>
        /// 找回密码模板码
        /// </summary>
        public string RetrieveCode { get; set; }
    }
}
