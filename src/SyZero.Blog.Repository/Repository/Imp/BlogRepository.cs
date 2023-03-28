using SyZero.SqlSugar.Repositories;

namespace SyZero.Blog.Repository
{
    public class BlogRepository : SqlSugarRepository<Core.BlogManagement.Blog>, IBlogRepository
    {
        public string GetTest()
        {

            return "xxxxxx";

        }


    }
}



