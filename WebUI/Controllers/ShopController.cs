using Application.Features.Shops.Commands;
using Application.Features.Shops.Dtos;
using Application.Features.Shops.Queries;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("shops")]
    public class ShopController : ApiControllerBase
    {
        private readonly ILogger<ShopController> _logger;
        public ShopController(ILogger<ShopController> logger)
        {
            _logger = logger;
        }

        [HttpPost("shop")]
        public async Task<ActionResult<Response<Shop>>> CreateCategory([FromBody] CreateShopCommand query)
        => await Mediator.Send(query);

        [HttpGet("shops")]
        public async Task<ActionResult<PagedResponse<IEnumerable<ShopDto>>>> CreateCategory([FromQuery] GetShopsQuery query)
        => await Mediator.Send(query);


    }
}
