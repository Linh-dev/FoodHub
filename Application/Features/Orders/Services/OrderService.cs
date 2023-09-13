using Application.Common.Services;
using Application.Features.Orders.Commands;
using Application.Features.Orders.Dtos;
using Application.Features.ShopProducts.Dtos;
using Application.Features.ShopProducts.Services;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Services
{
    public class OrderService : CrudService<Order>, IOrderService
    {
        private readonly IProductService _productService;
        private readonly IRepository<Customer, Guid> Customers;
        private readonly IRepository<Products, Guid> Products;
        private readonly IRepository<Shop, Guid> Shops;
        public OrderService(
             IRepository<Order, Guid> repository,
             IRepository<Customer, Guid> Customers,
             IRepository<Products, Guid> Products,
             IRepository<Shop, Guid> Shops,
             IProductService productService)
            : base(repository)
        {
            _productService = productService;
            this.Customers = Customers;
            this.Shops = Shops;
            this.Products = Products;
        }

        public async Task<bool> AddOrders(CreateOrderCommand request)
        {
            try
            {
                foreach (var item in request.Orders)
                {
                    var entity = new Order()
                    {
                        CustomerId = request.CustommerId,
                        ProductId = item.ProductId,
                        DeliverDate = item.DeliverDate,
                        ShopId = _productService.GetByIdAsync(item.ProductId).Result.ShopId,
                        ProductPrice = _productService.GetByIdAsync(item.ProductId).Result.Price
                    };
                    await AddOrUpdateAsync(entity);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IQueryable<OrderDto>> GetOrdersAsync()
        {
            return  GetAsync().Join(Customers.GetAll(), ord => ord.CustomerId, cus => cus.Id, (ord, cus) => new { Order = ord, Customer = cus })
                .Join(Products.GetAll(), orc => orc.Order.ProductId, pr => pr.Id, (orc, pr) => new { Order = orc.Order, Customer = orc.Customer, Product = pr })
                .Join(Shops.GetAll(), info => info.Order.ShopId, sh => sh.Id, (info, sh) => new { Order = info.Order, Customer = info.Customer, Product = info.Product, Shop = sh })
                .Select(x => new OrderDto()
                {
                    Id= x.Order.Id,
                    ShopId = x.Order.ShopId,
                    ShopName = x.Shop.Name,
                    ShopLocation = x.Shop.Location,
                    CustomerId = x.Order.Id,
                    CustomerName = x.Customer.FullName,
                    CustomerEmail = x.Customer.Email,
                    ProductId = x.Order.ProductId,
                    ProductName = x.Product.Name,
                    ProductPrice = x.Order.ProductPrice,
                });
        }
    }
}
