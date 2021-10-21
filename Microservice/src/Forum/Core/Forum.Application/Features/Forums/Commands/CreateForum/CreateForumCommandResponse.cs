using Common.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.Forums.Commands.CreateForum
{
   public class CreateForumCommandResponse:BaseResponse
    {

        public CreateForumCommandResponse() : base()
        {

        }

        public CreateForumDto Forum { get; set; }

    }
}
