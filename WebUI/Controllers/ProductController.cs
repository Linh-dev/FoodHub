using Application.Features.ShopProducts.Command;
using Application.Features.ShopProducts.Dtos;
using Application.Features.ShopProducts.Queries;
using Application.Features.Shops.Commands;
using Application.Features.Shops.Dtos;
using Application.Features.Shops.Queries;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("shop-products")]
    public class ProductController : ApiControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpPost("product")]
        public async Task<ActionResult<Response<Products>>> CreateProduct([FromBody] CreateProductCommand query)
        => await Mediator.Send(query);

        [HttpGet("products")]
        public async Task<ActionResult<PagedResponse<IEnumerable<ProductDto>>>> GetProducts([FromQuery] GetProductsQuery query)
        => await Mediator.Send(query);
    }
}
