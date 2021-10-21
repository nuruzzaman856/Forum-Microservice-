using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.PostReplies.Commands.DeletePostReplies
{
    public class DeletePostRepliesCommand : IRequest
    {

        public Guid PostReplyId { get; set; }

    }
}
