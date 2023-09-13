using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TodoItem : BaseEntity
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public  int PriorityLevel { get; set; }

    }
}
