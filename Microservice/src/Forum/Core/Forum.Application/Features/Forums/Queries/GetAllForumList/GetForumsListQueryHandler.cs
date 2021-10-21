using AutoMapper;
using Forum.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Features.Forums.Queries.GetAllForumList
{
    public class GetForumsListQueryHandler : IRequestHandler<GetForumsListQuery, IEnumerable<ForumsVm>>
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public GetForumsListQueryHandler(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ForumsVm>> Handle(GetForumsListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _forumRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ForumsVm>>(orderList);
        }
    }
}
