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

namespace Forum.Application.Features.PostReplies.Commands.UpdatePostReplies
{
    public class UpdatePostRepliesCommandHandler : IRequestHandler<UpdatePostRepliesCommand>
    {

        private readonly IMapper _mapper;
        private readonly IAsyncRepository<PostReply> _postReplyRepository;

        public UpdatePostRepliesCommandHandler(IMapper mapper, IAsyncRepository<PostReply> postReplyRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _postReplyRepository = postReplyRepository ?? throw new ArgumentNullException(nameof(postReplyRepository));
        }


        public async Task<Unit> Handle(UpdatePostRepliesCommand request, CancellationToken cancellationToken)
        {
            var postReplyToUpdate = await _postReplyRepository.GetByIdAsync(request.PostReplyId);

            //mapping the Changes through the Auto Mapper in database enties
            _mapper.Map(request, postReplyToUpdate, typeof(UpdatePostRepliesCommand), typeof(PostReply));

            return Unit.Value;
        }
    }
}
