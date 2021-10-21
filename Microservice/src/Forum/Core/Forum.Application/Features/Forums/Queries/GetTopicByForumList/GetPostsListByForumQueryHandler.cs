using AutoMapper;
using Forum.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Features.Forums.Queries.GetTopicByForumList
{
    public class GetPostsListByForumQueryHandler : IRequestHandler<GetPostsListByForumQuery, IEnumerable<PostsListByForumVm>>
    {
        private readonly IForumRepository _forumRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostsListByForumQueryHandler(IForumRepository forumRepository, IPostRepository postRepository, IMapper mapper)
        {
            _forumRepository = forumRepository ?? throw new ArgumentNullException(nameof(forumRepository));
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<PostsListByForumVm>> Handle(GetPostsListByForumQuery request, CancellationToken cancellationToken)
        {
            var forum = await _forumRepository.GetByIdAsync(request.ForumId);
            var posts = await _postRepository.GetFilteredPostByForum("wuw-wer78w5t6-r7ew8");

            throw new NotImplementedException();

        }
    }
}
