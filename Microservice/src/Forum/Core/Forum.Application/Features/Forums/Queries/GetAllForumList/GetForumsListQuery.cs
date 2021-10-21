using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.Forums.Queries.GetAllForumList
{
    public class GetForumsListQuery: IRequest<IEnumerable<ForumsVm>>
    {
    }
}
