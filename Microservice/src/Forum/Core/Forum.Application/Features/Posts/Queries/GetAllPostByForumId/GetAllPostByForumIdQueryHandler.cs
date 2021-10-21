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

namespace Forum.Application.Features.Posts.Queries.GetAllPostByForumId
{
    public class GetAllPostByForumIdQueryHandler : IRequestHandler<GetAllPostByForumIdQuery, List<GetAllPostByForumIdVm>>
    {

        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostByForumIdQueryHandler(IAsyncRepository<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetAllPostByForumIdVm>> Handle(GetAllPostByForumIdQuery request, CancellationToken cancellationToken)
        {
            var forum = await _postRepository.GetByIdAsync(request.ForumId);
            return _mapper.Map<List<GetAllPostByForumIdVm>>(forum);
        }
    }
}
