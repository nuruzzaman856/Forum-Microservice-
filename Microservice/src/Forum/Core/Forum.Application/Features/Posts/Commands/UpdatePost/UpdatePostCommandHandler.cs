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

namespace Forum.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {


        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Post> _postRepository;

        public UpdatePostCommandHandler(IMapper mapper, IAsyncRepository<Post> postRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        }


        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var postToUpdate = await _postRepository.GetByIdAsync(request.PostId);

            //mapping the Changes through the Auto Mapper in database enties
            _mapper.Map(request, postToUpdate, typeof(UpdatePostCommand), typeof(Post));

            return Unit.Value;
        }
    }
}
