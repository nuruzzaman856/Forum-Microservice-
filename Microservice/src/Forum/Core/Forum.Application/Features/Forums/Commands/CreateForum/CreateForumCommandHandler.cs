using AutoMapper;
using Forum.Application.Contracts.Persistence;
using Forum.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Features.Forums.Commands.CreateForum
{
    public class CreateForumCommandHandler : IRequestHandler<CreateForumCommand, CreateForumCommandResponse>
    {
        private readonly IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public CreateForumCommandHandler(IForumRepository forumRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateForumCommandResponse> Handle(CreateForumCommand request, CancellationToken cancellationToken)
        {
            //var forum = _mapper.Map<ForumEntity>(request);

            //forum = await _forumRepository.AddAsync(forum);

            //return forum.Id;



            var createForumCommandResponse = new CreateForumCommandResponse();
            //validating the data coming from the user to create a Forum
            var validator = new CreateForumValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createForumCommandResponse.Success = false;
                createForumCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createForumCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createForumCommandResponse.Success)
            {
                var NewForum = new ForumEntity()
                {
                    Title = request.Title,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl
                    
                };

                NewForum = await _forumRepository.AddAsync(NewForum);

                //Not Clear about that 
                createForumCommandResponse.Forum = _mapper.Map<CreateForumDto>(NewForum);
            }
            return createForumCommandResponse;
        }
    }
}
