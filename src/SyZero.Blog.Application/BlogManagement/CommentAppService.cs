using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZero.Blog.Core.BlogManagement;
using SyZero.Blog.IApplication.BlogManagement;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Domain.Repository;

namespace SyZero.Blog.Application.BlogManagement
{
    public class CommentAppService : AsyncCrudAppService<Comment, CommentDto>, ICommentAppService
    {
        private readonly IRepository<Comment> _commentRepository;
        public CommentAppService(IRepository<Comment> commentRepository) : base(commentRepository)
        {
            _commentRepository = commentRepository;
        }
    }
}
