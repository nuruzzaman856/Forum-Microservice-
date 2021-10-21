using System;

namespace Forum.Application.Features.Forums.Queries.GetAllForumList
{
    //like ForumListingModel
    public class ForumsVm
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
