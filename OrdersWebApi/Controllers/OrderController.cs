using Application.Order.Commands.CreateOrder;
using Application.Order.Commands.UpdateOrder;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.DTOs.Order;

namespace OrdersWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public OrderController(IMediator mediator, IMapper mapper, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateOrder(CreateOrderDTO createOrderDTO, CancellationToken cancellationToken)
        {
            await _mediator.Send(_mapper.Map<CreateOrderCommand>(createOrderDTO), cancellationToken);
            _logger.LogInformation($"Order on user with id: {createOrderDTO.UserId} created.");

            return Ok();
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateOrder(UpdateOrderDTO updateOrderDTO, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(_mapper.Map<UpdateOrderCommand>(updateOrderDTO), cancellationToken);
            _logger.LogInformation($"Order on user with id: {id} created.");

            return Ok(id);
        }
    }
}
