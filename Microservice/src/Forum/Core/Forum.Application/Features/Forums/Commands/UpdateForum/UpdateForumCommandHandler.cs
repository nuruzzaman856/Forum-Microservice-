using AutoMapper;
using Common.Services.Repositories;
using Forum.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Features.Forums.Commands.UpdateForum
{
    public class UpdateForumCommandHandler : IRequestHandler<UpdateForumCommand>
    {
        private readonly IAsyncRepository<ForumEntity> _forumRepository;
        private readonly IMapper _mapper;

        public UpdateForumCommandHandler(IAsyncRepository<ForumEntity> forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(UpdateForumCommand request, CancellationToken cancellationToken)
        {
            var forumToUpdate = await _forumRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, forumToUpdate, typeof(UpdateForumCommand), typeof(ForumEntity));

            await _forumRepository.UpdateAsync(forumToUpdate);

            return Unit.Value;
        }
    }
}
