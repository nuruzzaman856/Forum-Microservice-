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

namespace Forum.Application.Features.PostReplies.Queries.GetAllPostReplyListById
{
    public class GetAllPostReplyListByIdQureyHandler : IRequestHandler<GetAllPostReplyListByIdQuery, GetAllPostReplyListByIdVm>
    {

        private readonly IAsyncRepository<PostReply> _asyncRepository;
        private readonly IMapper _mapper;

        public GetAllPostReplyListByIdQureyHandler(IAsyncRepository<PostReply> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository ?? throw new ArgumentNullException(nameof(asyncRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetAllPostReplyListByIdVm> Handle(GetAllPostReplyListByIdQuery request, CancellationToken cancellationToken)
        {
            var forum = await _asyncRepository.GetByIdAsync(request.PostReplyId);
            return _mapper.Map<GetAllPostReplyListByIdVm>(forum);
        }
    }
}
