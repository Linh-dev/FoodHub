using Application.Common.Handlers;
using Application.Common.Interfaces;
using Application.Features.ShopProducts.Services;
using Application.Features.Shops.Commands;
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

namespace Application.Features.ShopProducts.Command
{
    public class CreateProductCommand : IRequest<Response<Products>>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid ShopId { get; set; }

        [Required]
        public double Price { get; set; }
    }

    public class CreateProductCommandHandler : BaseHandler<CreateProductCommand, Response<Products>>
    {
        private readonly IProductService _productService;
        public CreateProductCommandHandler(ICommonService commonService, IProductService productService) : base(commonService)
        {
            _productService = productService;
        }

        public override async Task<Response<Products>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Products() { Name = request.Name, Price = request.Price , ShopId = request.ShopId};
            var result = await _productService.AddOrUpdateAsync(entity);
            return Response<Products>.Success(result);
        }
    }
}