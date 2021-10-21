 using System;

namespace Forum.Application.Features.Posts.Queries.GetAllPostList
{
    public class GetAllPostListVm
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
