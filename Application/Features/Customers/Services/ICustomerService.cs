using Application.Common.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Services
{
    public interface ICustomerService : ICrudService<Customer>
    {
    }
}
