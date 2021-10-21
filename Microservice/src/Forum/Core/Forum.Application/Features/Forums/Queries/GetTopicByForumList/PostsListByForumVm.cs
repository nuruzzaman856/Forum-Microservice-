using System;

namespace Forum.Application.Features.Forums.Queries.GetTopicByForumList
{
    public class PostsListByForumVm
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public int AuthorRating { get; set; }
        public string Title { get; set; }
        public DateTime DatePosted { get; set; }
        public int RepliesCount { get; set; }

    }
}
