using AutoMapper;
using Forum.Application.Features.Forums.Commands.CreateForum;
using Forum.Application.Features.Forums.Commands.DeleteForum;
using Forum.Application.Features.Forums.Commands.UpdateForum;
using Forum.Application.Features.Forums.Queries.GetAllForumList;
using Forum.Application.Features.Forums.Queries.GetByIdList;
using Forum.Application.Features.Forums.Queries.GetTopicByForumList;
using Forum.Application.Features.PostReplies.Commands.CreatePostReplies;
using Forum.Application.Features.PostReplies.Commands.DeletePostReplies;
using Forum.Application.Features.PostReplies.Commands.UpdatePostReplies;
using Forum.Application.Features.Posts.Commands.CreatePost;
using Forum.Application.Features.Posts.Commands.DeletePost;
using Forum.Application.Features.Posts.Commands.UpdatePost;
using Forum.Application.Features.Posts.Queries.GetAllPostList;
using Forum.Domain.Entities;

namespace Forum.Application.Profiles
{
    public class MappingProfiler: Profile
    {
        public MappingProfiler()
        {
            CreateMap<ForumEntity, ForumsVm>().ReverseMap();
            CreateMap<ForumEntity, ForumGetByIdListVm>().ReverseMap();
            CreateMap<ForumEntity, PostsListByForumVm>().ReverseMap();
            CreateMap<ForumEntity, CreateForumCommand>().ReverseMap();
            CreateMap<ForumEntity, UpdateForumCommand>().ReverseMap();
            CreateMap<ForumEntity, DeleteForumCommand>().ReverseMap();

            CreateMap<ForumEntity, CreateForumDto>().ReverseMap();



            CreateMap<Post, CreatePostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();
            CreateMap<Post, DeletePostCommand>().ReverseMap();
            CreateMap<Post, GetAllPostListVm>().ReverseMap();





            CreateMap<PostReply, CreatePostRepliesCommand>().ReverseMap();
            CreateMap<PostReply, UpdatePostRepliesCommand>().ReverseMap();
            CreateMap<PostReply, DeletePostRepliesCommand>().ReverseMap();



        }
    }
}
