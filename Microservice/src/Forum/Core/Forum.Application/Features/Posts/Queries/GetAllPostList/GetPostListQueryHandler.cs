using AutoMapper;
using Common.Services.Repositories;
using Forum.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Features.Posts.Queries.GetAllPostList
{
    public class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, List<GetAllPostListVm>>
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public GetPostListQueryHandler(IAsyncRepository<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetAllPostListVm>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var allPost = await _postRepository.GetAllAsync();
            return _mapper.Map<List<GetAllPostListVm>>(allPost);
        }
    }
}
