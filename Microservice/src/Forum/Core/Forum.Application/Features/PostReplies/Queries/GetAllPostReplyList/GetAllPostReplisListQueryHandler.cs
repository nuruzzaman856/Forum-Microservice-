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

namespace Forum.Application.Features.PostReplies.Queries.GetAllPostReplyList
{
    public class GetAllPostReplisListQueryHandler : IRequestHandler<GetAllPostRepliesListQuery, List<GetAllPostRepliesListVm>>
    {
        private readonly IAsyncRepository<PostReply> _postReplyRepository;
        private readonly IMapper _mapper;

        public GetAllPostReplisListQueryHandler(IAsyncRepository<PostReply> postRepository, IMapper mapper)
        {
            _postReplyRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetAllPostRepliesListVm>> Handle(GetAllPostRepliesListQuery request, CancellationToken cancellationToken)
        {
            var allPostReply = await _postReplyRepository.GetAllAsync();
            return _mapper.Map<List<GetAllPostRepliesListVm>>(allPostReply);
        }
    }
}
