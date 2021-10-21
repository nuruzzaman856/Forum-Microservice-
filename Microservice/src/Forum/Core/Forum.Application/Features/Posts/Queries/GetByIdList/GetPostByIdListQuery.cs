using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.Posts.Queries.GetByIdList
{
   public class GetPostByIdListQuery : IRequest<GetPostByIdListVm>
    {

        public Guid Id { get; set; }


    }
}
