
using Forum.Application.Features.Posts.Commands.CreatePost;
using Forum.Application.Features.Posts.Commands.DeletePost;
using Forum.Application.Features.Posts.Commands.UpdatePost;
using Forum.Application.Features.Posts.Queries.GetAllPostList;
using Forum.Application.Features.Posts.Queries.GetByIdList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZForum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("ClientIdPolicy")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all", Name = "GetAllPost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetAllPostListVm>>> GetAll()
        {
            var forums = await _mediator.Send(new GetPostListQuery());
            return Ok(forums);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public async Task<ActionResult<List<GetPostByIdListVm>>> GetById(Guid id)
        {
            var getForumListByIdQuery = new GetPostByIdListQuery() { Id = id };
            return Ok(await _mediator.Send(getForumListByIdQuery));
        }

        [HttpPost(Name = "AddPost")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePostCommand createPostCommand)
        {
            var id = await _mediator.Send(createPostCommand);
            return Ok(id);
        }


        [HttpPut(Name = "UpdatePost")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdatePostCommand updatePostCommad)
        {
            await _mediator.Send(updatePostCommad);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePostCommand = new DeletePostCommand() { PostId = id };
            await _mediator.Send(deletePostCommand);
            return NoContent();
        }


    }
}
