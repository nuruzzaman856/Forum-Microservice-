using Common.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandResponse : BaseResponse
    {


        public CreatePostCommandResponse() : base()
        {

        }

        public CreatePostCommand Post { get; set; }
    }
}
