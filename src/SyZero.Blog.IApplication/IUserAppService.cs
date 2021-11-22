using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Attributes;
using SyZero.Application.Service;

namespace SyZero.Blog.IApplication
{
    public interface IUserAppService : IApplicationService
    {
        object GetUserAll(int oqw);
    }
}



