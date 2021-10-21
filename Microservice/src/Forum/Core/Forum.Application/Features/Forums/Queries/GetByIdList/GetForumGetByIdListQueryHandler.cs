using AutoMapper;
using Common.Services.Repositories;
using Forum.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Features.Forums.Queries.GetByIdList
{
    public class GetForumGetByIdListQueryHandler : IRequestHandler<GetForumGetByIdListQuery, ForumGetByIdListVm>
    {
        private readonly IAsyncRepository<ForumEntity> _asyncRepository;
        private readonly IMapper _mapper;

        public GetForumGetByIdListQueryHandler(IAsyncRepository<ForumEntity> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository ?? throw new ArgumentNullException(nameof(asyncRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ForumGetByIdListVm> Handle(GetForumGetByIdListQuery request, CancellationToken cancellationToken)
        {
            var forum = await _asyncRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ForumGetByIdListVm>(forum);
        }
    }
}
