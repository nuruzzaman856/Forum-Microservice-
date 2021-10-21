using Forum.Application.Contracts.Persistence;
using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ForumDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Post>> GetFilteredPostByForum(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetPostByForum(Guid ForumId)
        {
            var postbyforum =  _dbContext.Forums
               .Where(forum => forum.Id == ForumId).First().Posts;
            return postbyforum;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            var getAllPost = await _dbContext.Posts
                        .Include(post => post.User)
                        .Include(post => post.Replies).ThenInclude(reply => reply.User)
                        .Include(post => post.Forum)
                        .ToListAsync();
            return getAllPost;
        }

        public async Task<IEnumerable<Post>> GetById(Guid Id)
        {
            var postById = await _dbContext.Posts
                       .Where(post => post.Id == Id)
                       .Include(post => post.User)
                       .Include(post => post.Replies).ThenInclude(reply => reply.User)
                       .Include(post => post.Forum)
                       .FirstAsync();
            return (IEnumerable<Post>)postById;
        }

        public async Task<IEnumerable<Post>> GetLatestPosts(int n)
        {
          return  GetAll().Result.OrderByDescending(post => post.CreateAt).Take(n);

        }

        public async Task<IEnumerable<Post>> GetFilteredPosts(int Id, string searchQuery)
        {
            var forum =  _dbContext.Forums.Find(Id);
            return  string.IsNullOrEmpty(searchQuery)
                   ? forum.Posts
                   : forum.Posts
                   .Where(post => post.Title.Contains(searchQuery)  
                   || post.Content.Contains(searchQuery) );
        }





        //public IEnumerable<Post> GetPostByForum(Guid ForumId)
        //{
        //    var postbyforam = _dbContext.Forums
        //       .Where(forum => forum.Id == ForumId).First().Posts;
        //    return postbyforam;
        //}


    }
}
