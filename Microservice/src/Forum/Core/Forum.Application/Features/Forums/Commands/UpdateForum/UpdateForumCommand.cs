using MediatR;
using System;

namespace Forum.Application.Features.Forums.Commands.UpdateForum
{
    public class UpdateForumCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
