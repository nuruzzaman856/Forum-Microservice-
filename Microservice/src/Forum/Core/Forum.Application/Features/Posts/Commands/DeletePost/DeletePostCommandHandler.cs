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

namespace Forum.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {

        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Post> _postRepository;

        public DeletePostCommandHandler(IMapper mapper, IAsyncRepository<Post> postRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        }




        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var postToDelete = await _postRepository.GetByIdAsync(request.PostId);
            await _postRepository.DeleteAsync(postToDelete);

            return Unit.Value;
        }
    }
}
