using Forum.Application.Contracts.Persistence;
using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Persistence.Repositories
{
    public class ForumRepository : BaseRepository<ForumEntity>, IForumRepository
    {
        public ForumRepository(ForumDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<ForumEntity>> GetAll()
        {
            return await _dbContext.Forums.Include(forum => forum.Posts).ToListAsync();
        }

        public async Task<IEnumerable<ForumEntity>> GetAllPostByForum(Guid ForumId)
        {
            var forum = await _dbContext.Forums.Where(f => f.Id == ForumId)
                    .Include(f => f.Posts).ThenInclude(p => p.User)
                    .Include(f => f.Posts).ThenInclude(p => p.Replies).ThenInclude(r => r.User)
                    .ToListAsync();
            return forum;
        }
    }
}
