
using SyZero.Blog.Core.Users;
using SyZero.SqlSugar.Repositories;

namespace SyZero.Blog.Repository
{
    public class UserRepository : SqlSugarRepository<User>, IUserRepository
    {
        public string GetTest()
        {

            return "xxxxxx";

        }


    }
}



