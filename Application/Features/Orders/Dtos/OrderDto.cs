using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Features.Orders.Dtos
{
    public class OrderDto : IMapFrom<Order>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }
        public Guid ShopId { get; set; }

        public string ShopName { get; set; }

        public string ShopLocation { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public DateTimeOffset DeliverDate { get; set; }

        public string CustomerInfo => CustomerName + " - " + CustomerEmail;

        public string ShopInfo => ShopName + " - " + ShopLocation;

        public string ProductInfo => ProductName + " - " + ProductPrice.ToString();
    }
}
