using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp5.Entities;

namespace Tp5.DTO
{
    public class CustomerOrdersQuantity
    {
        public Customer Customer { get; set; }
        public int OrdersQuantity { get; set; }
    }
}
