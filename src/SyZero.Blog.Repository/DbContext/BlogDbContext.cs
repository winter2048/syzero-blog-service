
using Microsoft.Extensions.Logging;
using SqlSugar;
using System;
using SyZero.SqlSugar.DbContext;
using SyZero.Util;

namespace SyZero.Blog.Repository
{
    public class BlogDbContext : SyZeroDbContext
    {
        public BlogDbContext(ConnectionConfig config) : base(config)
        {

        }
    }
}



