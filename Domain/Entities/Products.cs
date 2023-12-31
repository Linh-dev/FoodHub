﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Products : AggregateRoot<Guid>
    {
        public Guid ShopId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
