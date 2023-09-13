using Application.Common.Services;
using Application.Features.ShopProducts.Dtos;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ShopProducts.Services
{
    public class ProductService : CrudService<Products>, IProductService
    {
        private readonly IRepository<Shop, Guid> Shops;
        public ProductService(IRepository<Products, Guid> repository, IRepository<Shop, Guid> Shops) : base(repository)
        {
            this.Shops = Shops;
        }

        public async Task<IQueryable<ProductDto>> GetProductsAsync(Expression<Func<Products, bool>> predicate = null)
        {
           return GetAsync(predicate).Join(Shops.GetAll(), pr => pr.ShopId, sh => sh.Id, (pr, sh) => new { Product = pr, Shop = sh }).Select(x => new ProductDto()
            {
                Id= x.Product.Id,
                ShopId = x.Shop.Id,
                ShopName = x.Shop.Name,
                Price = x.Product.Price,
                Name = x.Product.Name,
            });
        }
    }
}
