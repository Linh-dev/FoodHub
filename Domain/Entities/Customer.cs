using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : AggregateRoot<Guid>
    {
        public string FullName { get; set; }

        public string Email { get; set; }   

        public DateTimeOffset DOB { get; set; }
    }
}
