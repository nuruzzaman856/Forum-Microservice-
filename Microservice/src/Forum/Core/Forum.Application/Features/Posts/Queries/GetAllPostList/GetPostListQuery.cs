using MediatR;
using System.Collections.Generic;

namespace Forum.Application.Features.Posts.Queries.GetAllPostList
{
    public class GetPostListQuery : IRequest<List<GetAllPostListVm>>
    {
    }
}
