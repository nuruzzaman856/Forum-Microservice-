using Forum.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Forum.Application.Features.Forums.Commands.CreateForum
{
    public class CreateForumCommand : IRequest<CreateForumCommandResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
