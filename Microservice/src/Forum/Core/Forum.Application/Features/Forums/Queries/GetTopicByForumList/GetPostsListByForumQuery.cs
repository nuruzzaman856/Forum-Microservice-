using MediatR;
using System;
using System.Collections.Generic;

namespace Forum.Application.Features.Forums.Queries.GetTopicByForumList
{
    public class GetPostsListByForumQuery: IRequest<IEnumerable<PostsListByForumVm>>
    {
        public Guid ForumId { get; set; }

    }
}
