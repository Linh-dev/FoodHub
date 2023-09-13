using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Shops.Services;
using System.Security.AccessControl;
using Application.Features.Shops.Dtos;

namespace Application.Features.Shops.Queries
{
    public class GetShopsQuery : IRequest<PagedResponse<IEnumerable<ShopDto>>>
    {
        public string? Name { get; set; }
        [DefaultValue(1)]
        public int? PageNumber { get; set; } = 1;
        [DefaultValue(20)]
        public int? PageSize { get; set; } = 20;
    }

    public class GetShopsQueryHandler : BaseHandler<GetShopsQuery, PagedResponse<IEnumerable<ShopDto>>>
    {
        private readonly IShopService _shopService;
        public GetShopsQueryHandler(ICommonService commonService, IShopService shopService) : base(commonService)
        {
            _shopService = shopService;
        }

        public override async Task<PagedResponse<IEnumerable<ShopDto>>> Handle(GetShopsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Shop, bool>> predicate =  !string.IsNullOrEmpty(request.Name) ? x => x.Name.Contains(request.Name) : null;

            var results =  _shopService.GetAsync(predicate);

            return new PagedResponse<IEnumerable<ShopDto>>(
                 Mapper.Map<IEnumerable<ShopDto>>(results.OrderByDescending(x=>x.Location).Skip(request.PageNumber.Value - 1).Take(request.PageSize.Value)),
                 request.PageNumber,
                 request.PageSize,
                 totalRecordCount: results.Count()
                );
        }
    }
  }
