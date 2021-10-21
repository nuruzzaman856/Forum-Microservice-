using Forum.Application.Features.PostReplies.Commands.CreatePostReplies;
using Forum.Application.Features.PostReplies.Commands.DeletePostReplies;
using Forum.Application.Features.PostReplies.Commands.UpdatePostReplies;
using Forum.Application.Features.PostReplies.Queries.GetAllPostReplyList;
using Forum.Application.Features.PostReplies.Queries.GetAllPostReplyListById;
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
    public class PostRepliesController : ControllerBase
    {
        private readonly IMediator _mediator;


        [HttpGet("all", Name = "GetAllPostReply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GetAllPostRepliesListVm>>> GetAll()
        {
            var forums = await _mediator.Send(new GetAllPostRepliesListQuery());
            return Ok(forums);
        }

        [HttpGet("{id}", Name = "GetPostReplyById")]
        public async Task<ActionResult<List<GetAllPostReplyListByIdVm>>> GetById(Guid id)
        {
            var getForumListByIdQuery = new GetAllPostReplyListByIdQuery() { PostReplyId = id };
            return Ok(await _mediator.Send(getForumListByIdQuery));
        }


        [HttpPost(Name = "AddPostReply")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePostRepliesCommand createPostRepliesCommand)
        {
            var id = await _mediator.Send(createPostRepliesCommand);
            return Ok(id);
        }


        [HttpPut(Name = "UpdatePostReply")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdatePostRepliesCommand updatePostRepliesCommad)
        {
            await _mediator.Send(updatePostRepliesCommad);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeletePostReply")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePostReplyCommand = new DeletePostRepliesCommand() { PostReplyId = id };
            await _mediator.Send(deletePostReplyCommand);
            return NoContent();
        }

    }
}
