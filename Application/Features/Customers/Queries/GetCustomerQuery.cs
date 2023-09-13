using Application.Common.Handlers;
using Application.Common.Interfaces;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Services;
using Application.Features.Shops.Dtos;
using Application.Features.Shops.Queries;
using Application.Features.Shops.Services;
using AutoMapper;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries
{
    public class GetCustomerQuery : IRequest<PagedResponse<IEnumerable<CustomerDto>>>
    {
        public string? SearchString { get; set; }
        [DefaultValue(1)]
        public int? PageNumber { get; set; } = 1;
        [DefaultValue(20)]
        public int? PageSize { get; set; } = 20;
    }

    public class GetCustomerQueryHandler : BaseHandler<GetCustomerQuery, PagedResponse<IEnumerable<CustomerDto>>>
    {
        private readonly ICustomerService _customerService;
        public GetCustomerQueryHandler(ICommonService commonService, ICustomerService customerService) : base(commonService)
        {
            _customerService = customerService;
        }

        public override async Task<PagedResponse<IEnumerable<CustomerDto>>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Customer, bool>> predicate = !string.IsNullOrEmpty(request.SearchString) ? x => (x.FullName.Contains(request.SearchString) ||x.Email.Contains(request.SearchString)): null;

            var results = _customerService.GetAsync(predicate);

            return new PagedResponse<IEnumerable<CustomerDto>>(
                 Mapper.Map<IEnumerable<CustomerDto>>(results.OrderBy(x => x.Email).Skip(request.PageNumber.Value - 1).Take(request.PageSize.Value)),
                 request.PageNumber,
                 request.PageSize,
                 totalRecordCount: results.Count()
                );
        }
    }
}
