using Common.Services.Repositories;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Contracts.Persistence
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostByForum(Guid ForumId);
        Task<IEnumerable<Post>> GetFilteredPostByForum(string searchQuery);
        Task<IEnumerable<Post>> GetFilteredPosts(int Id ,string searchQuery);

        Task<IEnumerable<Post>> GetAll();
        Task<IEnumerable<Post>> GetById(Guid Id);
        Task<IEnumerable<Post>> GetLatestPosts(int n);





    }
}
