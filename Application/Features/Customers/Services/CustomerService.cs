using Application.Common.Services;
using Application.Features.Shops.Services;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Services
{
    public class CustomerService : CrudService<Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer, Guid> repository) : base(repository)
        {
        }
    }
}
