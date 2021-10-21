using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.Posts.Queries.GetAllPostByForumId
{
    public class GetAllPostByForumIdQuery : IRequest<List<GetAllPostByForumIdVm>>
    {

        public Guid ForumId { get; set; }
    }
}
