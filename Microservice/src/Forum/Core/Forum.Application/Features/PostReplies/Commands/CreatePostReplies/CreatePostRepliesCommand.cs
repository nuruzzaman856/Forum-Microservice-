using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.PostReplies.Commands.CreatePostReplies
{
    public class CreatePostRepliesCommand : IRequest<CreatePostRepliesCommandResponse>
    {

        public Guid PostReplyId { get; set; }
        public string Content { get; set; }



    }
}
