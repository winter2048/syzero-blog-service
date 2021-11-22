using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero.Blog.Core.Authorization.Users;

namespace SyZero.Blog.Repository
{
    public class UserRepository : BlogRepositoryBase<User>, IUserRepository
    {
        public UserRepository(BlogDbContext dbContextProvider):base(dbContextProvider)
        {

        }

        public async Task<string> GetTest()
        {
            return "xxxxxx";

        }


    }
}



