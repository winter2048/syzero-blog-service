﻿using SyZero.Domain.Repository;

namespace SyZero.Blog.Repository
{
    public interface IBlogRepository : IRepository<Core.BlogManagement.Article>
    {
        string GetTest();
    }
}



