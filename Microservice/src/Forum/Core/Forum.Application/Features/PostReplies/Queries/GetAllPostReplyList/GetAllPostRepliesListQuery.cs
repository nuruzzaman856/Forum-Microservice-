using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.PostReplies.Queries.GetAllPostReplyList
{
   public class GetAllPostRepliesListQuery : IRequest<List<GetAllPostRepliesListVm>>
    {
    }
}
