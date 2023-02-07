using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyZero.Blog.IApplication.BlogManagement.Dto
{
    public class Login2Dto
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public int Type { get; set; } = 0;
    }
}
