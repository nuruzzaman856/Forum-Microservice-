using MediatR;
using System;

namespace Forum.Application.Features.Forums.Queries.GetByIdList
{
    public class GetForumGetByIdListQuery: IRequest<ForumGetByIdListVm>
    {
        public Guid Id { get; set; }

    }
}
