using Common.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.PostReplies.Commands.CreatePostReplies
{
    public class CreatePostRepliesCommandResponse : BaseResponse
    {

        public CreatePostRepliesCommandResponse() : base()
        {

        }
        public CreatePostRepliesCommand PostReply { get; set; }

    }
}
