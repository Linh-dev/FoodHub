using Application.Features.Customers.Commands;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Queries;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("customers")]
    public class CustomerController : ApiControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("customer")]
        public async Task<ActionResult<Response<Customer>>> CreateCategory([FromBody] CreateCustomerCommand query)
        => await Mediator.Send(query);

        [HttpGet("customers")]
        public async Task<ActionResult<PagedResponse<IEnumerable<CustomerDto>>>> CreateCategory([FromQuery] GetCustomerQuery query)
        => await Mediator.Send(query);


    }
}
