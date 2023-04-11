using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZero.Application.Service.Dto;
using SyZero.Authorization.IApplication.Users;
using SyZero.Blog.Core.BlogManagement;
using SyZero.Blog.IApplication.BlogManagement;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Domain.Repository;

namespace SyZero.Blog.Application.BlogManagement
{
    public class CommentAppService : AsyncCrudAppService<Comment, CommentDto>, ICommentAppService
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly IUserAppService _userAppService;

        public CommentAppService(IRepository<Comment> commentRepository,
            IUserAppService userAppService) : base(commentRepository)
        {
            _commentRepository = commentRepository;
            _userAppService = userAppService;
        }

        public async Task<PageResultDto<CommentDto>> GetBlogComment(long BlogId, PageAndSortQueryDto input)
        {
            var commentList = (await _commentRepository.GetListAsync(p => p.BlogId == BlogId)).ToList().Where(p => p.ParentId == null).OrderByDescending(p => p.CreateTime).AsQueryable();
            var totalCount = commentList.Count();

            commentList = ApplySorting(commentList, input);
            commentList = ApplyPaging(commentList, input);

            var entities = commentList.ToList();

            var dtoList = commentList.ToList().Select(MapToEntityDto).ToList();
            foreach (var item in dtoList)
            {
              //  item.Childs = treeToList(item.Childs.ToList());
            }
            return new PageResultDto<CommentDto>(
                totalCount,
                dtoList
            );
        }

        public async Task<bool> SendComment(long BlogId, CreateCommentDto dto)
        {
            var entity = ObjectMapper.Map<Comment>(dto);
            entity.BlogId = BlogId;
            if (SySession.UserId == null)
            {
                entity.Author = "游客";
            }
            else
            {
                entity.Author = (await _userAppService.GetUser(SySession.UserId.Value)).NickName;
                entity.CreateUserId = SySession.UserId.Value;
            }

            await _commentRepository.AddAsync(entity);
            return true;
        }
    }
}
