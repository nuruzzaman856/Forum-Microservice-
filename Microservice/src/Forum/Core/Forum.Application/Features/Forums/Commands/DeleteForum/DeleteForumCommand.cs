using MediatR;
using System;

namespace Forum.Application.Features.Forums.Commands.DeleteForum
{
    public class DeleteForumCommand : IRequest
    {
        public Guid ForumId { get; set; }

    }
}
