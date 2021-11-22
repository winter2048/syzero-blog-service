using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero.Dependency;
using SyZero.Domain.Repository;
using SyZero.Blog.Core.Authorization.Users;

namespace SyZero.Blog.Repository
{
    public interface IUserRepository : IRepository<User>
    {
       Task<string> GetTest();
    }
}



