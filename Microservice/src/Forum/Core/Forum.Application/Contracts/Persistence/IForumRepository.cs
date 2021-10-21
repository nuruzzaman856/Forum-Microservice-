using Common.Services.Repositories;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Contracts.Persistence
{
    public interface IForumRepository : IAsyncRepository<ForumEntity>
    {
        Task<IEnumerable<ForumEntity>> GetAll();
        Task<IEnumerable<ForumEntity>> GetAllPostByForum(Guid ForumId);

    }
}
