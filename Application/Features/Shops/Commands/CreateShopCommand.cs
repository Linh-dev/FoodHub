using Application.Common.Handlers;
using Application.Common.Interfaces;
using Application.Features.Shops.Services;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shops.Commands
{
    public class CreateShopCommand : IRequest<Response<Shop>>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
    }

    public class CreateShopCommandHandler : BaseHandler<CreateShopCommand, Response<Shop>>
    {
        private readonly IShopService _shopService;
        public CreateShopCommandHandler(ICommonService commonService, IShopService shopService) : base(commonService)
        {
            _shopService = shopService;
        }

        public override async Task<Response<Shop>> Handle(CreateShopCommand request, CancellationToken cancellationToken)
        {
            var entity = new Shop() { Name = request.Name, Location = request.Location };
            var result = await _shopService.AddOrUpdateAsync(entity);
            return Response<Shop>.Success(result);
        }
    }
}