using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Client;

namespace SyZero.Blog.IApplication
{
    public class UserAppServiceFallback : IUserAppService, IFallback
    {
        public object GetUserAll(int oqw)
        {
            return "出错";
        }
    }
}
