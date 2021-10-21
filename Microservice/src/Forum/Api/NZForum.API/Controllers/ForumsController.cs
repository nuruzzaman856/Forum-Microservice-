using Forum.Application.Features.Forums.Commands.CreateForum;
using Forum.Application.Features.Forums.Commands.DeleteForum;
using Forum.Application.Features.Forums.Commands.UpdateForum;
using Forum.Application.Features.Forums.Queries.GetAllForumList;
using Forum.Application.Features.Forums.Queries.GetByIdList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NZForum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("ClientIdPolicy")]
    public class ForumsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ForumsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("all", Name = "GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ForumsVm>>> GetAll()
        {
            var forums = await _mediator.Send(new GetForumsListQuery());
            return Ok(forums);
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<List<ForumGetByIdListVm>>> GetById(Guid id)
        {
            var getForumListByIdQuery = new GetForumGetByIdListQuery() { Id = id };
            return Ok(await _mediator.Send(getForumListByIdQuery));
        }

        [HttpPost(Name = "AddForum")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateForumCommand createForumCommand)
        {
            var id = await _mediator.Send(createForumCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateForum")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateForumCommand updateForumCommad)
        {
            await _mediator.Send(updateForumCommad);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteForum")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteForumCommand = new DeleteForumCommand() { ForumId = id };
            await _mediator.Send(deleteForumCommand);
            return NoContent();
        }
    }
}
