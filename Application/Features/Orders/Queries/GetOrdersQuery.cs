using Application.Common.Handlers;
using Application.Features.Orders.Dtos;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Features.Orders.Services;
using System.Linq.Expressions;

namespace Application.Features.Orders.Queries
{
    public class GetOrdersQuery : IRequest<PagedResponse<IEnumerable<OrderDto>>>
    {
        [DefaultValue(1)]
        public int? PageNumber { get; set; } = 1;
        [DefaultValue(20)]
        public int? PageSize { get; set; } = 20;
}

public class GetOrdersQueryHandler : BaseHandler<GetOrdersQuery, PagedResponse<IEnumerable<OrderDto>>>
{
    private readonly IOrderService _orderService;
    public GetOrdersQueryHandler(ICommonService commonService, IOrderService orderService) : base(commonService)
    {
        _orderService = orderService;
    }

    public override async Task<PagedResponse<IEnumerable<OrderDto>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var results = await _orderService.GetOrdersAsync();

        return new PagedResponse<IEnumerable<OrderDto>>(
             Mapper.Map<IEnumerable<OrderDto>>(results.Skip(request.PageNumber.Value - 1).Take(request.PageSize.Value)),
             request.PageNumber,
             request.PageSize,
             totalRecordCount: results.Count()
            );
    }
}
}
