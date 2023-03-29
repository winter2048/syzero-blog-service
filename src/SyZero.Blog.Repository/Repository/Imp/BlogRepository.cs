using SyZero.SqlSugar.Repositories;

namespace SyZero.Blog.Repository
{
    public class BlogRepository : SqlSugarRepository<Core.BlogManagement.Article>, IBlogRepository
    {
        public string GetTest()
        {

            return "xxxxxx";

        }


    }
}



