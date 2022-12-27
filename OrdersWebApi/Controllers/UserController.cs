using Application.User.Commands.CreateUser;
using Application.User.Commands.RemoveUser;
using Application.User.Commands.UpdateUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.DTOs.User;

namespace OrdersWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, IMapper mapper, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateUser(CreateUserDTO createUserDTO, CancellationToken cancellationToken)
        {
            await _mediator.Send(_mapper.Map<CreateUserCommand>(createUserDTO), cancellationToken);
            _logger.LogInformation("User created.");

            return Ok();
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> RemoveUser(int userId, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new RemoveUserCommand { UserId = userId }, cancellationToken);
            _logger.LogInformation($"User with id: {id} removed.");

            return Ok(id);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateUser(UpdateUserDTO updateUserDTO, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(_mapper.Map<UpdateUserCommand>(updateUserDTO), cancellationToken);
            _logger.LogInformation($"User with id: {id} updated.");

            return Ok(id);
        }
    }
}
