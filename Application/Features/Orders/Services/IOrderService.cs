using Application.Common.Services;
using Application.Features.Orders.Commands;
using Application.Features.Orders.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Services
{
    public interface IOrderService : ICrudService<Order>
    {
        Task<bool> AddOrders(CreateOrderCommand request);

        Task<IQueryable<OrderDto>> GetOrdersAsync();
    }
}
