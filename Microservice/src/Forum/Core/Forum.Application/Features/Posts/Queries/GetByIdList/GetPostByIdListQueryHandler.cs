using AutoMapper;
using Common.Services.Repositories;
using Forum.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Features.Posts.Queries.GetByIdList
{
    public class GetPostByIdListQueryHandler : IRequestHandler<GetPostByIdListQuery, GetPostByIdListVm>
    {

        private readonly IAsyncRepository<Post> _asyncRepository;
        private readonly IMapper _mapper;

        public GetPostByIdListQueryHandler(IAsyncRepository<Post> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository ?? throw new ArgumentNullException(nameof(asyncRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetPostByIdListVm> Handle(GetPostByIdListQuery request, CancellationToken cancellationToken)
        {
            var post = await _asyncRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetPostByIdListVm>(post);
        }
    }
}
