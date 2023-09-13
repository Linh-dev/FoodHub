using Application.Common.Handlers;
using Application.Common.Interfaces;
using Application.Features.Customers.Services;
using Application.Features.Orders.Services;
using Application.Features.Shops.Commands;
using Application.Features.Shops.Services;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands
{
    public class OrderInfo 
    { 
        public Guid ProductId { get; set; }
        public DateTime DeliverDate { get; set; }
    }
    public class CreateOrderCommand : IRequest<Response<bool>>
    {
        public Guid CustommerId { get; set; }
        public List<OrderInfo> Orders { get; set; }
    }

    public class CreateShopCommandHandler : BaseHandler<CreateOrderCommand, Response<bool>>
    {
        private readonly IOrderService _orderService;
        public CreateShopCommandHandler(ICommonService commonService, IOrderService orderService) : base(commonService)
        {
            _orderService = orderService;
        }

        public override async Task<Response<bool>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderService.AddOrders(request);
            return Response<bool>.Success(result);
        }
    }

}
