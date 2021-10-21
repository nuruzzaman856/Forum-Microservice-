using Forum.Application.Contracts.Persistence;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Persistence.Repositories
{
    public class PostReplyRepository : BaseRepository<PostReply>, IPostReplyRepository
    {
        public PostReplyRepository(ForumDbContext dbContext) : base(dbContext)
        {

        }
    }
}
