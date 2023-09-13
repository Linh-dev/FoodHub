using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ShopProducts.Dtos
{
    public class ProductDto : IMapFrom<Products>
    {
        public Guid Id { get; set; }
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
