using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp5.Data;
using Tp5.DTO;
using Tp5.Entities;

namespace TpLinqLogic
{
    public class CustomerLogic
    {
        private readonly NorthwindContext _context;

        public CustomerLogic()
        {
            _context = new NorthwindContext();
        }
        public Customer GetCustomer()
        {
            return _context.Customers.FirstOrDefault();
        }

        public List<Customer> GetWACustomers()
        {
            return _context
                .Customers
                .Where(x => x.Region == "WA")
                .ToList();
        }

        public List<CustomerNames> GetCustomerNames()
        {
            return _context
                .Customers
                .Select(x => new CustomerNames { CustomerNameLower = x.ContactName.ToLower(), CustomerNameUpper = x.ContactName.ToUpper() })
                .ToList();
        }

        public List<CustomerOrders> GetCustomersOrders()
        {
            var date = Convert.ToDateTime("1-1-1997");
            var customerOrders = from customer in _context.Customers
                         join order in _context.Orders on customer equals order.Customer
                         where customer.Region == "WA" && order.OrderDate >= date
                                 group order by customer into co
                         select new CustomerOrders { Customer = co.Key, Orders = co.ToList() };

            return customerOrders.ToList();
        }

        public List<Customer> GetFirstCustomersOfWARegion()
        {
            return _context
                .Customers
                .Where(x => x.Region == "WA")
                .Take(3)
                .ToList();     
        }

        public List<CustomerOrdersQuantity> GetCustomerOrdersQuantity()
        {
            var customerOrders = from customer in _context.Customers
                            join order in _context.Orders on customer equals order.Customer
                            group order by customer into co
                            select new CustomerOrdersQuantity { Customer = co.Key, OrdersQuantity = co.Count() };

            return customerOrders.ToList();
        }
    }
}
