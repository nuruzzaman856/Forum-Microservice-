using AutoMapper;
using Common.Services.Repositories;
using Forum.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Features.Forums.Commands.DeleteForum
{
    public class DeleteForumCommandHandler : IRequestHandler<DeleteForumCommand>
    {
        private readonly IAsyncRepository<ForumEntity> _forumRepository;
        private readonly IMapper _mapper;

        public DeleteForumCommandHandler(IAsyncRepository<ForumEntity> forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Unit> Handle(DeleteForumCommand request, CancellationToken cancellationToken)
        {
            var forumToDelete = await _forumRepository.GetByIdAsync(request.ForumId);
            await _forumRepository.DeleteAsync(forumToDelete);

            return Unit.Value;
        }
    }
}
