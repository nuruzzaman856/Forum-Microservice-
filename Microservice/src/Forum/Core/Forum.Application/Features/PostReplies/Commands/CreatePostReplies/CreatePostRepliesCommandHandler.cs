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

namespace Forum.Application.Features.PostReplies.Commands.CreatePostReplies
{
    public class CreatePostRepliesCommandHandler : IRequestHandler<CreatePostRepliesCommand, CreatePostRepliesCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostReplyRepository _postReplyRepository;

        public CreatePostRepliesCommandHandler(IMapper mapper, IPostReplyRepository postReplyRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _postReplyRepository = postReplyRepository ?? throw new ArgumentNullException(nameof(postReplyRepository));
        }


        public async Task<CreatePostRepliesCommandResponse> Handle(CreatePostRepliesCommand request, CancellationToken cancellationToken)
        {
            //mapping the data of Post REplies with the help of Auto Mapper for database

            var createPostRepliesCommandResponse = new CreatePostRepliesCommandResponse();
            var validator = new CreatePostRepliesValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createPostRepliesCommandResponse.Success = false;
                createPostRepliesCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createPostRepliesCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createPostRepliesCommandResponse.Success)
            {
                var NewPostReply = new PostReply()
                {
                    Content = request.Content

                };

                NewPostReply = await _postReplyRepository.AddAsync(NewPostReply);

                //did not understand that, is it will work
                createPostRepliesCommandResponse.PostReply = _mapper.Map<CreatePostRepliesCommand>(NewPostReply);

            }



            return createPostRepliesCommandResponse;

        }
    }
}
