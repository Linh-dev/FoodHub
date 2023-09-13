using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : AggregateRoot<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid ShopId { get; set; }
        public Guid ProductId { get; set; }
        public double ProductPrice { get; set; }
        public DateTimeOffset DeliverDate { get; set; }
    }
}
