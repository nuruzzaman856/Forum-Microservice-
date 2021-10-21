using Forum.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.Posts.Commands.CreatePost
{
   public class CreatePostCommand: IRequest<CreatePostCommandResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual ApplicationUser User { get; set; }

        //public Guid ForumId { get; set; }
        public virtual ForumEntity Forum { get; set; }

        public virtual IEnumerable<PostReply> Replies { get; set; }

    }
}
