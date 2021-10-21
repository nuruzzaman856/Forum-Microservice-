using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest
    {

        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
