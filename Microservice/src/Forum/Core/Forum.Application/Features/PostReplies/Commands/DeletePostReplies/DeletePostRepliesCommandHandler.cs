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

namespace Forum.Application.Features.PostReplies.Commands.DeletePostReplies
{
    public class DeletePostRepliesCommandHandler : IRequestHandler<DeletePostRepliesCommand>
    {

        private readonly IMapper _mapper;
        private readonly IAsyncRepository<PostReply> _postReplyRepository;

        public DeletePostRepliesCommandHandler(IMapper mapper, IAsyncRepository<PostReply> postReplyRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _postReplyRepository = postReplyRepository ?? throw new ArgumentNullException(nameof(postReplyRepository));
        }



        public async Task<Unit> Handle(DeletePostRepliesCommand request, CancellationToken cancellationToken)
        {
            var postReplyToDelete = await _postReplyRepository.GetByIdAsync(request.PostReplyId);
            await _postReplyRepository.DeleteAsync(postReplyToDelete);

            return Unit.Value;
        }
    }
}
