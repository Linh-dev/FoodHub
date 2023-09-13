using Application.Common.Handlers;
using Application.Common.Interfaces;
using Application.Features.ShopProducts.Dtos;
using Application.Features.ShopProducts.Services;
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

namespace Application.Features.ShopProducts.Queries
{
    public class GetProductsQuery : IRequest<PagedResponse<IEnumerable<ProductDto>>>
    {
        public string? Name { get; set; }
        [DefaultValue(1)]
        public int? PageNumber { get; set; } = 1;
        [DefaultValue(20)]
        public int? PageSize { get; set; } = 20;
    }

    public class GetProductsQueryHandler : BaseHandler<GetProductsQuery, PagedResponse<IEnumerable<ProductDto>>>
    {
        private readonly IProductService _productService;
        public GetProductsQueryHandler(ICommonService commonService, IProductService productService) : base(commonService)
        {
            _productService = productService;
        }

        public override async Task<PagedResponse<IEnumerable<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Products, bool>> predicate = !string.IsNullOrEmpty(request.Name) ? x => x.Name.Contains(request.Name) : null;

            var results = await _productService.GetProductsAsync(predicate);

            return new PagedResponse<IEnumerable<ProductDto>>(
                 Mapper.Map<IEnumerable<ProductDto>>(results.OrderByDescending(x => x.Price).Skip(request.PageNumber.Value - 1).Take(request.PageSize.Value)),
                 request.PageNumber,
                 request.PageSize,
                 totalRecordCount: results.Count()
                );
        }
    }
}
