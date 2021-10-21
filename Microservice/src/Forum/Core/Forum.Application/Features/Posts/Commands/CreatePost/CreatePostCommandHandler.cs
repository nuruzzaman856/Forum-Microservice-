using AutoMapper;
using Forum.Application.Contracts.Persistence;
using Forum.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostCommandResponse>
    {

        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        }



        public async Task<CreatePostCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {

            var createPostCommandResponse = new CreatePostCommandResponse();

            var validator = new CreatePostValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createPostCommandResponse.Success = false;
                createPostCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    createPostCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createPostCommandResponse.Success)
            {
                var NewPost = new Post()
                {
                    Title = request.Title,
                    Content = request.Content


                };

                NewPost = await _postRepository.AddAsync(NewPost);
                //not sure is it going to work
                createPostCommandResponse.Post = _mapper.Map<CreatePostCommand>(NewPost);
            }



            return createPostCommandResponse;
        }
    }
}
