using Application.Features.Orders.Commands;
using Application.Features.Orders.Dtos;
using Application.Features.Orders.Queries;
using Application.Features.Shops.Commands;
using Application.Features.Shops.Dtos;
using Application.Features.Shops.Queries;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("orders")]
    public class OrderController : ApiControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpPost("order")]
        public async Task<ActionResult<Response<bool>>> CreateOrder([FromBody] CreateOrderCommand query)
        => await Mediator.Send(query);

        [HttpGet("orders")]
        public async Task<ActionResult<PagedResponse<IEnumerable<OrderDto>>>> GetOrders([FromQuery] GetOrdersQuery query)
        => await Mediator.Send(query);


    }
}
