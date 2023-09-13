using Application.Common.Services;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shops.Services
{
    public class ShopService : CrudService<Shop>, IShopService
    {
        public ShopService(IRepository<Shop, Guid> repository) : base(repository)
        {

        }
    }
}
