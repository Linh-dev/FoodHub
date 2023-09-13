using Application.Common.Services;
using Application.Features.ShopProducts.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ShopProducts.Services
{
    public interface IProductService : ICrudService<Products>
    {
        Task<IQueryable<ProductDto>> GetProductsAsync(Expression<Func<Products, bool>> predicate = null);
    }
}
